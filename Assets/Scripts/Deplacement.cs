using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Deplacement : MonoBehaviour
{
    public List<GameObject> trains;
    public GameObject[] children;
    private float vitesse ;
    public float vitessemin = 2;
    public float vitessemax = 5;
    private float vitesseTMP;
    [Range(0,1)] public float pourcentage = 0.5f;
    private bool touch = true;
    //private RayCast ray;
    //private bool flag;
    

    private void Awake()
    {

        //children = gameObject.GetComponentsInChildren<GameObject>();
        //for (int i = 0; i < children.Length; i++)
        //{
        //    if (children[i].tag == "Roues")
        //        trains[i] = children[i];
        //}
        //ray = Camera.main.GetComponent<RayCast>();
    }
    void Start()
    {
        vitessemoyenne(vitessemin, vitessemax);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * vitesse *Time.deltaTime);
        foreach (GameObject roue in trains)
        {
            roue.transform.RotateAround(roue.transform.position, Vector3.forward, -vitesse*200 * Time.deltaTime);
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, - transform.right, out hit, 1))
        {
            if (hit.transform.CompareTag("Voitures"))
            {
             
                hit.transform.gameObject.GetComponent<Deplacement>().vitesse *= 1.01f;
                //vitesseTMP = vitesse;
                //StartCoroutine("ResetVitesse");

                if (touch == true)
                {
                    //FMODUnity.RuntimeManager.PlayOneShot("event:/Klaxon", transform.position);
                    touch = false;
                }

            }
            else
            {
                touch = true;
            }
           
         
        }

        
        // print(gameObject.name + vitesse);

    }

    /*IEnumerator ResetVitesse()
    {             
        vitesse = 0;
        yield return new WaitForSeconds(2);
        vitesse = vitesseTMP * pourcentage;
    }*/
    

    float vitessemoyenne(float min, float max)
    {
        vitesse = Random.Range(min, max);
        return vitesse;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, - transform.right * 1);
        Gizmos.DrawWireSphere(transform.position + ray.decalage,0.2f);
    }*/
}
