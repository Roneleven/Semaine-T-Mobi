using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class OnTriggerEvents : MonoBehaviour
{
    public UnityEvent TriggerEnterEvent;
    public UnityEvent TriggerExitEvent;

    public List<string> reactToTags = new List<string>();


    private new Collider collider;

    void Awake()
    {
        collider = GetComponent<Collider>();
    }

    void Start()
    {
        if(!collider.isTrigger)
            Debug.LogWarningFormat("Collider of {0} not set as Trigger. Events will not work.", gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if(TriggerEnterEvent != null && (reactToTags.Count == 0 || reactToTags.Contains(other.tag))) TriggerEnterEvent.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        if(TriggerExitEvent != null && (reactToTags.Count == 0 || reactToTags.Contains(other.tag))) TriggerExitEvent.Invoke();
    }
}
