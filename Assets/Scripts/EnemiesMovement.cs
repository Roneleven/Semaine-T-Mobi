using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        // Translate the GameObject along its forward direction with a constant speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
