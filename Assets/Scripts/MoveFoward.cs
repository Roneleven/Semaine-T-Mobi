using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveFoward : MonoBehaviour
{
    public float speed;
    private bool hit = false;
    private CharacterControler charC;

    private void Start()
    {
        if(tag == "Player")
        {
            charC = GetComponent<CharacterControler>();
        }
    }

    void FixedUpdate()
    {
        //move foward automatically with delta time
        transform.position += (Vector3.forward * speed * Time.deltaTime);

        if (hit)
        {
            if (speed > 0)
            {
                speed -= 0.5f;
            }
            if (speed <= 0)
            {
                speed = 0;
                hit = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies") && tag == "Player")
        {
            Destroy(other.gameObject);
            charC.hasTouched = false;
            charC.isStunned = true;
            hit = true;
        }
    }


}
