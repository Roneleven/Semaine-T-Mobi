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
        Debug.Log("Trigger entered");
        if (other.CompareTag("Road"))
        {
            // Vérifie si la liste n'est pas vide
            if (routesListe.Length > 0)
            {
                // Génère un index aléatoire pour la liste
                int randomIndex = Random.Range(0, routesListe.Length);

                // Instancie le GameObject correspondant à l'index aléatoire
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