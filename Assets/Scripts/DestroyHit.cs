using UnityEngine;

public class RoadGeneratorr: MonoBehaviour
{
    public LayerMask roadLayer;
    public float raycastDistance = 100f;

    public Transform spawnRoadTarget; // The empty transform to teleport to
    [SerializeField]
    private Transform containerRoutes;

    public GameObject[] routesListe; // Tableau de GameObjects

    void FixedUpdate()
    {
        // Créer un raycast vers le bas depuis la position de ce gameObject
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, roadLayer))
        {
            Debug.Log("ok");
            // Si le raycast touche un objet avec le tag "Road", le détruire
            if (hit.collider.gameObject.CompareTag("Road"))
            {
                Debug.Log("Touché");
                Destroy(hit.collider.gameObject);

                /*// Vérifie si la liste n'est pas vide
                if (routesListe.Length > 0)
                {
                    // Génère un index aléatoire pour la liste
                    int randomIndex = Random.Range(0, routesListe.Length);

                    // Instancie le GameObject correspondant à l'index aléatoire
                    GameObject spawnedObject = Instantiate(routesListe[randomIndex], spawnRoadTarget.position, spawnRoadTarget.rotation, containerRoutes);
                }*/

            }
        }

        // Dessiner une ligne pour visualiser le raycast dans la scène Unity
        Debug.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance, Color.red);
    }
}
