using UnityEngine;
using System.Collections.Generic;

public class RoadGenerator : MonoBehaviour
{
    public LayerMask roadLayer;
    public float raycastDistance = 100f;

    public Transform spawnRoadTarget; // The empty transform to teleport to
    [SerializeField]
    private Transform containerRoutes;

    public List<GameObject> routeFacile;
    public List<GameObject> routeDifficile;

    [SerializeField]
    private TruckMovement distanceCamion;

    void Update()
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
                SpawnRoad();

            }
        }
        // Dessiner une ligne pour visualiser le raycast dans la scène Unity
        Debug.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance, Color.red);
    }

    void SpawnRoad()
    {
        if (distanceCamion.distanceTraveled >= 1000)
        {
            // Génère un GameObject aléatoire de la liste 2
            int index = Random.Range(0, routeDifficile.Count);
            Instantiate(routeDifficile[index], spawnRoadTarget.position, Quaternion.identity);
        }
        else
        {
            // Génère un GameObject aléatoire de la liste 1
            int index = Random.Range(0, routeFacile.Count);
            Instantiate(routeFacile[index], spawnRoadTarget.position, Quaternion.identity);
        }
    }
}
