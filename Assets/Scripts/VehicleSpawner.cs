using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> prefabToSpawn; // GameObject to spawn
    private float spawnDelay; // Delay between spawning objects
    public Transform containerEnemies;

    private float nextSpawnTime = 0f;

    [SerializeField]
    private float speedmin;
    [SerializeField]
    private float speedMax;
    public float ratemin;
    public float rateMax;



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
            spawnDelay = Random.Range(ratemin, rateMax); 
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, prefabToSpawn.Count);
        // Instancie le GameObject correspondant � l'index al�atoire
        GameObject spawnedObject = Instantiate(prefabToSpawn[randomIndex], transform.position, transform.rotation, containerEnemies);
        spawnedObject.GetComponent<EnemiesMovement>().speed = Random.Range(speedmin, speedMax);
    }
}







/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> prefabToSpawn; // GameObject to spawn
    public List<Transform> spawnPoints; // List of spawn points
    public float spawnDelay = 3f; // Delay between spawning objects
    public Transform containerEnemies;

    private float nextSpawnTime = 0f;

    [SerializeField]
    private float speedmin;
    [SerializeField]
    private float speedMax;

    [SerializeField]
    private float speedminL;
    [SerializeField]
    private float speedMaxL;




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

        int randomIndex = Random.Range(0, prefabToSpawn.Count);
        // Instancie le GameObject correspondant � l'index al�atoire
        GameObject spawnedObject = Instantiate(prefabToSpawn[randomIndex], spawnPoint.position, spawnPoint.rotation, containerEnemies);


        // R�cup�re le GameObject de l'enfant � partir de spawnPoint
        GameObject childObject = spawnPoint.gameObject;
        if (childObject.CompareTag("ContreSens"))
        {
            spawnedObject.GetComponent<EnemiesMovement>().speed = Random.Range(speedminL, speedMaxL);
        }
        else
        {
            spawnedObject.GetComponent<EnemiesMovement>().speed = Random.Range(speedmin, speedMax);
        }
    }
}*/
