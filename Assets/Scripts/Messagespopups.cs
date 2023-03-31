using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Messagespopups : MonoBehaviour
{
    public TruckMovement pommedeterre;
    private bool flag = true;
    public string[] listeMessages;
    TMP_Text textMessage;
    public float posYfinal = 860f;
    private Vector3 posFinal;
    private float t;
    public float tempsDanim = 1f;
    private bool arreteAnim = false ;
    // Start is called before the first frame update
    void Start()
    {
       textMessage = GetComponentInChildren<TMP_Text>();   
       posFinal = new Vector3(transform.position.x, posYfinal, transform.position.z);   
    }

    // Update is called once per frame
    void Update()
    {
        if (pommedeterre.distanceTraveled >= 50 && flag)
        {
            flag = false;
            //descendre l'affiche
            /*if (arreteAnim)
            {
                t += Time.deltaTime;
                float bruh = t / tempsDanim;
                transform.position = Vector3.Lerp(transform.position, posFinal, tempsDanim);
                if (bruh >= 1)
                {
                    transform.position = posFinal;
                    t = 0;  
                    arreteAnim = true;   
                }
            }*/
            transform.position = posFinal;  
            //afficher le messages
            textMessage.text = listeMessages[Random.Range(0, listeMessages.Length)];
            //son de notif
            //maintenir un certains temps
            //fade color texte et message
            //reset place
        }
    }
}
