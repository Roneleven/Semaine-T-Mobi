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
    public Transform initialPos;
    public TruckMovement pommedeterre;
    private bool flag = true;
    public string[] listeMessages;
    TMP_Text textMessage;
    private float t;
    public float tempsDanim = 2f;
    private bool arreteAnim = false ;
    private Image image;
    private int yo =1;
    // Start is called before the first frame update
    void Start()
    {
       textMessage = GetComponentInChildren<TMP_Text>();
       image = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (pommedeterre.distanceTraveled >= 250*yo && flag)
        {
            flag = false;
            yo++;
            image.material.DOFade(1, tempsDanim);
            transform.DOMove(finalPos.position,tempsDanim);
            //afficher le messages

            textMessage.text = listeMessages[Random.Range(0, listeMessages.Length)];
            //son de notif
            //maintenir un certains temps
            StartCoroutine(TempsDat());
            //fade color texte et message
            //reset place
        }
    }

    private IEnumerator TempsDat()
    {

        yield return new WaitForSeconds(5f);
        image.material.DOFade(0, tempsDanim);
        textMessage.text = " ";
        flag = true;
        transform.position = initialPos.position;
        yield return null;
    }
}
