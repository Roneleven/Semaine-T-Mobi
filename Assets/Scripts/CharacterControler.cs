using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class CharacterControler : MonoBehaviour
{
    Vector2 screenPos;
    public LayerMask layer;
    Rigidbody rb;
    public float lerpSpeed;
    public float lerpToMouseSpeed;
    LeanFinger finger;

    [HideInInspector] public bool hasTouched;
    [HideInInspector] public bool isStunned;
    public Transform ogPlayerPos;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
    }

    private void LeanTouch_OnFingerUp(LeanFinger obj)
    {
        hasTouched = false;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= LeanTouch_OnFingerDown; 
        LeanTouch.OnFingerUp -= LeanTouch_OnFingerUp;
    }

    private void LeanTouch_OnFingerDown(LeanFinger obj)
    {
        if (!isStunned)
        {
            finger = obj;
            hasTouched = true;
        }
    }

    private void FixedUpdate()
    {
        if (hasTouched)
        {
            screenPos = finger.ScreenPosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer))
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, lerpToMouseSpeed);
                //rb.MovePosition(Vector3.Lerp(transform.position, hit.point, lerpSpeed * Time.deltaTime));
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y,ogPlayerPos.position.z), lerpSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            Debug.Log("hit");
        }
    }
}
