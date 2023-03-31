using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> objectModels; // List of object models to spawn
    public float spawnDelay = 3f; // Delay between spawning objects
    public List<Transform> spawnPoints; // List of spawn points for objects
    public float minSpeed = 5f; // Minimum speed of spawned objects
    public float maxSpeed = 15f; // Maximum speed of spawned objects

    private float nextSpawnTime = 0f;

    void Start()
    {
        // Initialize the next spawn time based on the spawn delay
        nextSpawnTime = Time.deltaTime + spawnDelay;
    }

    void Update()
    {
        // Only spawn a new object if the time has passed the next spawn time
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.deltaTime + spawnDelay;
        }
    }

    void SpawnObject()
{
    // Choose a random vehicle from the array
    int index = Random.Range(0, objectModels.Count);
    GameObject vehiclePrefab = objectModels[index];

    // Choose a random spawn point from the array
    int spawnIndex = Random.Range(0, spawnPoints.Count);
    Transform spawnPoint = spawnPoints[spawnIndex];

    // Spawn the vehicle at the chosen spawn point with a random speed and fixed Z-axis direction
    GameObject vehicle = Instantiate(vehiclePrefab, spawnPoint.position, Quaternion.identity);
    Rigidbody vehicleRigidbody = vehicle.GetComponent<Rigidbody>();
    float speed = Random.Range(minSpeed, maxSpeed);
    Vector3 direction = new Vector3(0f, 0f, 1f);
    vehicleRigidbody.velocity = direction * speed;
    vehicle.transform.rotation = Quaternion.identity;
}

}