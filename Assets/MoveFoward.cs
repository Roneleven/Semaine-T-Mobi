using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed;
    void Update()
    {
        //move foward automatically with delta time
        transform.position += (Vector3.forward * speed * Time.deltaTime);

    }
}
