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

    private void Start()
    {
        if (tag == "Player")
        {
            charC = GetComponent<CharacterControler>();
        }

        distanceParcouru = GameObject.Find("DistanceParcouru").GetComponent<TruckMovement>();
    }

    void FixedUpdate()
    {

        // Incrémenter la vitesse de manière smooth tous les 500m
        if (distanceParcouru.distanceTraveled >= 500*step)
        {
            step++;
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
