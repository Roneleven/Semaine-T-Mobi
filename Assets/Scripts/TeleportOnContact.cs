using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public Transform teleportTarget; // The empty transform to teleport to
    [SerializeField]
    private Transform containerRoutes;

    // Listes de GameObjects pond�r�es
    [SerializeField]
    private List<GameObject> routesList60;
    [SerializeField]
    private List<GameObject> routesList30;
    [SerializeField]
    private List<GameObject> routesList10;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Road" tag
        Debug.Log("Trigger entered");
        if (other.CompareTag("Road"))
        {
            // V�rifie si la liste n'est pas vide
            if (routesList60.Count > 0 && routesList30.Count > 0 && routesList10.Count > 0)
            {
                // G�n�re un nombre al�atoire pour la pond�ration
                float randomWeight = Random.Range(0f, 1f);

                // D�termine quelle liste de GameObjects sera utilis�e en fonction de la pond�ration
                List<GameObject> chosenList = null;
                if (randomWeight <= 0.6f)
                {
                    chosenList = routesList60;
                }
                else if (randomWeight <= 0.9f)
                {
                    chosenList = routesList30;
                }
                else
                {
                    chosenList = routesList10;
                }

                // G�n�re un index al�atoire pour la liste choisie
                int randomIndex = Random.Range(0, chosenList.Count);

                // Instancie le GameObject correspondant � l'index al�atoire
                GameObject spawnedObject = Instantiate(chosenList[randomIndex], teleportTarget.position, teleportTarget.rotation, containerRoutes);
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogWarning("La liste de GameObjects ou le point de spawn est vide !");
            }
        }
    }
}
