using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;

public class CollisionManager : MonoBehaviour
{
public new ParticleSystem particleSystem; // Assign the particle system component in the inspector
public GameObject vehicle;

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemies"))
    {
        // Play the particle system
        if (particleSystem != null)
        {
            particleSystem.Play();
            Destroy(other.gameObject);
            Debug.Log("Vibration");
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.Failure);
            Destroy(vehicle);
        }
    }    
}
}
