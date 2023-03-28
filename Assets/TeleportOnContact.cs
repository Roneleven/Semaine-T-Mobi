using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public Transform teleportTarget; // The empty transform to teleport to

    public GameObject[] routesListe; // Tableau de GameObjects

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Road" tag
        Debug.Log("Trigger entered");
        if (other.CompareTag("Road"))
        {
            // Teleport the colliding object to the target position
            other.transform.position = teleportTarget.position;
            //Debug.Log("Teleported " + other.name);
        }
        // V�rifie si la liste n'est pas vide
        if (routesListe.Length > 0 && teleportTarget != null)
        {
            // G�n�re un index al�atoire pour la liste
            int randomIndex = Random.Range(0, routesListe.Length);

            // Instancie le GameObject correspondant � l'index al�atoire
            GameObject spawnedObject = Instantiate(routesListe[randomIndex], teleportTarget.position, teleportTarget.rotation);

            // Optionnel : modifie le parent du GameObject instanci�
            spawnedObject.transform.parent = transform;
        }
        else
        {
            Debug.LogWarning("La liste de GameObjects ou le point de spawn est vide !");
        }
    }
}