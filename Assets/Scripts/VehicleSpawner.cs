using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehicles; // Array of vehicle prefabs to spawn
    public float spawnDelay = 2f; // Delay between spawning vehicles
    public float spawnDistance = 50f; // Distance in front of player to spawn vehicles
    public Transform playerTransform; // Transform of the player

    private float nextSpawnTime;

    void Update()
    {
        // Only spawn a new vehicle if the time has passed the next spawn time
        if (Time.time >= nextSpawnTime)
        {
            SpawnVehicle();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnVehicle()
    {
        // Choose a random vehicle from the array
        int index = Random.Range(0, vehicles.Length);
        GameObject vehicle = vehicles[index];

        // Calculate the position to spawn the vehicle at (in front of the player)
        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnDistance;

        // Spawn the vehicle at the calculated position
        Instantiate(vehicle, spawnPosition, Quaternion.identity);
    }
}
