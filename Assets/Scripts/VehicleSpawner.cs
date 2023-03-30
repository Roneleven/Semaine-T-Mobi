using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // GameObject to spawn
    public List<Transform> spawnPoints; // List of spawn points
    public float spawnDelay = 3f; // Delay between spawning objects

    private float nextSpawnTime = 0f;

    void Start()
    {
        // Initialize the next spawn time based on the spawn delay
        nextSpawnTime = Time.time + spawnDelay;
    }

    void Update()
    {
        // Only spawn a new object if the time has passed the next spawn time
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnObject()
    {
        // Choose a random spawn point from the list
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Spawn the object at the chosen spawn point
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
