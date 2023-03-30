using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] Voitures;
    private float T;
    private float Apparition;
    public float tempsDapparitionmin;
    public float tempsDapparitionmax;

    void Start()
    {
        tempsDapparition(tempsDapparitionmin, tempsDapparitionmax);
        
    }

    
    void Update()
    {
        T += Time.deltaTime;
        if (T >= Apparition)
        {
            Instantiate(Voitures[(int)Random.Range(0, Voitures.Length -1)], transform.position, transform.rotation);
            T = 0;
            tempsDapparition(tempsDapparitionmin, tempsDapparitionmax);
            
        }
    }

    float tempsDapparition(float min, float max)
    {
        Apparition = Random.Range(min, max);
        return Apparition;
    }
}
