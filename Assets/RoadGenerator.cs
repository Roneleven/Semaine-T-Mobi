using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject[] roadPrefabs; // array of road prefabs to be used for generating the road
    public int numRoadPieces; // number of road pieces to generate
    public float roadLength; // length of each road piece
    public Transform startMarker; // transform marking the start of the road
    public Transform endMarker; // transform marking the end of the road
    public float destroyDistance; // distance from the end marker at which a road piece is destroyed

    private float nextSpawnDistance; // distance at which the next road piece will be spawned
    private Transform player; // reference to the player transform
    private GameObject lastRoadPiece; // reference to the last road piece spawned

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnDistance = roadLength;
        SpawnRoadPiece(startMarker.position);
    }

    private void Update()
    {
        if (player.position.z + destroyDistance > endMarker.position.z)
        {
            Destroy(lastRoadPiece);
            SpawnRoadPiece(lastRoadPiece.transform.position + Vector3.forward * roadLength);
        }
    }

    private void SpawnRoadPiece(Vector3 spawnPosition)
    {
        GameObject roadPrefab = roadPrefabs[Random.Range(0, roadPrefabs.Length)];
        GameObject roadPiece = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
        lastRoadPiece = roadPiece;
        nextSpawnDistance += roadLength;
    }
}
