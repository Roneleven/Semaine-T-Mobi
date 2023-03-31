using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemies"))
    {
        Destroy(other.gameObject);
        Debug.Log("Enemy Destroyed");
    }
}
}
