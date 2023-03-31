using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using DG.Tweening;

public class Messagespopups : MonoBehaviour
{
    public Transform finalPos;
    public TruckMovement pommedeterre;
    private bool flag = true;
    public string[] listeMessages;
    TMP_Text textMessage;
    public float posYfinal = 860f;
    private float t;
    public float tempsDanim = 1f;
    private bool arreteAnim = false ;
    // Start is called before the first frame update
    void Start()
    {
       textMessage = GetComponentInChildren<TMP_Text>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (pommedeterre.distanceTraveled >= 50 && flag)
        {
            flag = false;
            transform.DOMove(finalPos, 1f, false);
            //afficher le messages
            textMessage.text = listeMessages[Random.Range(0, listeMessages.Length)];
            //son de notif
            //maintenir un certains temps
            //fade color texte et message
            //reset place
        }
    }
}
