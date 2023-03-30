using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public LayerMask roadLayer;
    public float raycastDistance = 100f;

    public Transform spawnRoadTarget; // The empty transform to teleport to
    [SerializeField]
    private Transform containerRoutes;
    public GameObject route; // Tableau de GameObjects
    
    public float chronomax = 6.9999965f;
    private float chrono = 0f;

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
                //GameObject spawnedObject = Instantiate(route, spawnRoadTarget.position, spawnRoadTarget.rotation, containerRoutes);

            }
        }

        // Dessiner une ligne pour visualiser le raycast dans la scène Unity
        Debug.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance, Color.red);

        if (chrono >= chronomax)
        {
            Debug.Log("SpawnRoute");
            GameObject spawnedObject = Instantiate(route, spawnRoadTarget.position, spawnRoadTarget.rotation, containerRoutes);
            chrono = 0;
        }
        else
        {
            chrono += 0.1f;
        }
    }
}
