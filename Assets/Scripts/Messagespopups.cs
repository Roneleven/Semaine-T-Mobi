using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Lofelt.NiceVibrations;

public class Messagespopups : MonoBehaviour
{
    public Transform finalPos;
    public Transform initialPos;
    public TruckMovement pommedeterre;
    private bool flag = true;
    public string[] listeMessages;
    TMP_Text textMessage;
    public float tempsDanim = 2f;
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
        if (pommedeterre.distanceTraveled >= 500*yo && flag)
        {
            flag = false;
            yo++;
            image.material.DOFade(0.85f, tempsDanim);
            transform.DOMove(finalPos.position,tempsDanim);
            //afficher le messages

            textMessage.text = listeMessages[Random.Range(0, listeMessages.Length)];
            //son de notif
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI_IG-Notif");
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
