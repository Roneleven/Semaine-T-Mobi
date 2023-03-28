using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed;
    void Update()
    {
        //move foward automatically with delta time
        transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
