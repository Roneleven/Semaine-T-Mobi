using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
public new ParticleSystem particleSystem; // Assign the particle system component in the inspector

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemies"))
    {
        // Play the particle system
        if (particleSystem != null)
        {
            particleSystem.Play();
            Destroy(other.gameObject);
        }
    }
}
}
