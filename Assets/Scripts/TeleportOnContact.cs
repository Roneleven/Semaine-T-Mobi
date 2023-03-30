using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public Transform teleportTarget; // The empty transform to teleport to
    [SerializeField]
    private Transform containerRoutes;

    public GameObject[] routesListe; // Tableau de GameObjects

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Road" tag
        if (other.CompareTag("Road"))
        {
            // V�rifie si la liste n'est pas vide
            if (routesListe.Length > 0)
            {
                
                // G�n�re un index al�atoire pour la liste
                int randomIndex = Random.Range(0, routesListe.Length);

                // Instancie le GameObject correspondant � l'index al�atoire
                GameObject spawnedObject = Instantiate(routesListe[randomIndex], teleportTarget.position, teleportTarget.rotation, containerRoutes);
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogWarning("La liste de GameObjects ou le point de spawn est vide !");
            }
        }
    }
}