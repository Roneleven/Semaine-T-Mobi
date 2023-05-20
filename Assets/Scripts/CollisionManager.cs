using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
public new ParticleSystem particleSystem; // Assign the particle system component in the inspector

    public bool isDead = false;
    public GameObject vehicule;

    void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("Enemies"))
        {
            isDead = true;
            // Play the particle system
            if (particleSystem != null)
            {
                if (isDead)
                {
                    particleSystem.Play();
                    Destroy(other.gameObject);
                    HapticPatterns.PlayPreset(HapticPatterns.PresetType.Failure);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicule_Collision");
                    vehicule.SetActive(false);
                    Time.timeScale = 0;
                    isDead = false;
                }
                
            }
        }
    }
}
