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
    public List<GameObject> routeDifficile2;
    public int switchDistance = 1000; // Distance pour changer de liste

    private TruckMovement distanceCamion;

    private List<GameObject>[] routeLists; // Tableau contenant toutes les listes
    private int currentListIndex = 0; // Index de la liste actuelle

    void Start()
    {
        // Initialiser le tableau de listes
        routeLists = new List<GameObject>[3];
        routeLists[0] = routeFacile;
        routeLists[1] = routeDifficile;
        routeLists[2] = routeDifficile2;

        distanceCamion = GameObject.Find("DistanceParcouru").GetComponent<TruckMovement>();
    }

    void Update()
    {
        // Créer un raycast vers le bas depuis la position de ce gameObject
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, roadLayer))
        {
            // Si le raycast touche un objet avec le tag "Road", le détruire
            if (hit.collider.gameObject.CompareTag("Road"))
            {
                Destroy(hit.collider.gameObject);
                SpawnRoad();

            }
        }
        // Dessiner une ligne pour visualiser le raycast dans la scène Unity
        Debug.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance, Color.red);
    }

    void SpawnRoad()
    {
        if (distanceCamion.distanceTraveled >= 1500)
        {
            // Changer de liste tous les switchDistance mètres
            currentListIndex = (currentListIndex + 1) % routeLists.Length;
            switchDistance += switchDistance; // Mettre à jour la distance pour le prochain changement
        }

        // Générer un GameObject aléatoire de la liste actuelle
        int index = Random.Range(0, routeLists[currentListIndex].Count);
        Instantiate(routeLists[currentListIndex][index], spawnRoadTarget.position, Quaternion.identity);
    }
}
