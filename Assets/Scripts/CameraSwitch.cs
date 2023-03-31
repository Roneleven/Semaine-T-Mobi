using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform PosCam1; // La position et rotation de la caméra Camion
    public Transform PosCam2; // La position et rotation de la caméra Colis
    public float smoothSpeed = 0.125f; // La vitesse à laquelle la caméra se déplace

    public bool switchCam;
    public GameObject camCamion;
    public GameObject camColis;

    public GameObject camion;
    public GameObject colis;

    private Vector3 smoothVelocity = Vector3.zero;

    void Update()
    {
        // Si votre booléen est en true
        if (switchCam)
        {
            // Changez la position et la rotation de la caméra progressivement
            Vector3 desiredPosition = PosCam2.position;
            Quaternion desiredRotation = PosCam2.rotation;
            camCamion.transform.position = Vector3.SmoothDamp(camCamion.transform.position, desiredPosition, ref smoothVelocity, smoothSpeed);
            camCamion.transform.rotation = Quaternion.Lerp(camCamion.transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);

            if (camCamion.transform.position == desiredPosition) // FONCTIONNE PAS //
            {
                camColis.SetActive(true);
                colis.SetActive(true);
                camion.SetActive(false);
                camCamion.SetActive(false);
                Debug.Log("yes");
            }
        }
        if (switchCam == false)
        {
            // Changez la position et la rotation de la caméra progressivement
            Vector3 desiredPosition = PosCam1.position;
            Quaternion desiredRotation = PosCam1.rotation;
            camColis.transform.position = Vector3.SmoothDamp(camColis.transform.position, desiredPosition, ref smoothVelocity, smoothSpeed);
            camColis.transform.rotation = Quaternion.Lerp(camColis.transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
            
            if (camColis.transform.position == desiredPosition && camColis.transform.rotation == desiredRotation) // FONCTIONNE PAS AUSSI //
            {
                camCamion.SetActive(true);
                camion.SetActive(true);
                colis.SetActive(false);
                camColis.SetActive(false);
            }
        }
    }
}
