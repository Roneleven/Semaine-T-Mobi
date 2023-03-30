using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when q is pressed, move left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0, 0, -0.1f);
        }
        // when d is pressed, move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, 0.1f);
        }
        //move foward automatically
    }
}
