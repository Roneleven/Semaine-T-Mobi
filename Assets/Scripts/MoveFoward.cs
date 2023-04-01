using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed;
    private bool hit = false;
    private CharacterControler charC;
    private TruckMovement distanceParcouru;
    private float targetSpeed;
    public float increaseSpeed;
    private int step = 1;
    public float durationToSmooth = 0.5f;
    private FMOD.Studio.EventInstance event_fmod;
    public GameObject player;

    private float maxRPM = 300;


    private void Start()
    {

        if (tag == "Player")
        {
            charC = GetComponent<CharacterControler>();
        }

        distanceParcouru = GameObject.Find("DistanceParcouru").GetComponent<TruckMovement>();

        event_fmod = FMODUnity.RuntimeManager.CreateInstance("event:/Avatar_Vehicule_Moteur");
        event_fmod.setParameterByName("RPM", 400);
        event_fmod.setParameterByName("Load", 0.08f);
        event_fmod.start();


    }

    void FixedUpdate()
    {
        if (maxRPM < 1050)
        {
            event_fmod.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
            event_fmod.setParameterByName("RPM", maxRPM);
        }
        Debug.Log(maxRPM);

        // Incrémenter la vitesse de manière smooth tous les 500m
        if (distanceParcouru.distanceTraveled >= 500*step)
        {
            step++;
            maxRPM += 50 * step;
            targetSpeed = speed + increaseSpeed;
            StartCoroutine(ChangerLaValeurSmooth());
        }

        // Smooth Damp pour augmenter la vitesse de manière smooth
        //speed = Mathf.SmoothDamp(speed, targetSpeed, ref speed, 0.5f);

        // Déplacement automatique sur l'axe Z
        transform.position += (Vector3.forward * speed * Time.deltaTime);

        if (hit)
        {
            if (speed > 0)
            {
                speed -= 0.5f;
            }
            if (speed <= 0)
            {
                speed = 0;
                hit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies") && tag == "Player")
        {
            Destroy(other.gameObject);
            charC.hasTouched = false;
            charC.isStunned = true;
            hit = true;
        }
    }
    private IEnumerator ChangerLaValeurSmooth()
    {
        float elapse = 0f;
        while (elapse<durationToSmooth)
        {
            elapse += Time.deltaTime;
            speed = Mathf.Lerp(speed, targetSpeed, elapse / durationToSmooth);
            yield return new WaitForEndOfFrame();
        }
        speed = targetSpeed;
        yield return null;
    }
}
