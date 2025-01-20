using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Collider))]
public class Log : MonoBehaviour
{
    [SerializeField] GameObject logOne;
    [SerializeField] GameObject logTwo;

    Collider m_collider = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_collider = GetComponent<Collider>();
        m_collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Blade blade = null;
        if (other.CompareTag("Blade"))
        {
            blade = other.GetComponentInParent<Blade>();
        }

        if (blade==null) 
            return; //Quit this fucntion earlier if not blade script is found;

        if (blade.m_controllerDataReader == null)
            return;

        Split(); 

    }

    private void Split()
    {
        EnablePhysics(logOne);
        EnablePhysics(logTwo);

    }

    void EnablePhysics(GameObject log)
    {
        log.transform.parent = null;

        Rigidbody rg = log.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.isKinematic = false;
    }
        
}
