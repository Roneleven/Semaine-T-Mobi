using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public new ParticleSystem particleSystem; // Assign the particle system component in the inspector
    public GameObject Camion;
    public Score score;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            // Play the particle system
            if (particleSystem != null)
            {
                particleSystem.Play();
                Destroy(other.gameObject);
                // Destroy this game object
                Destroy(Camion);
                //restart the game
                SceneManager.LoadScene("Erwan Scene");
                // Update the score
                score.UpdateScore();
            }
        }    
    }
}