using System;
using UnityEngine;

/// <summary>
/// The log script purpose is to check wether its being hit by a blade and react accordingly.
/// 3  possible behaviours
/// </summary>
[RequireComponent(typeof(Collider))]
public class Log : MonoBehaviour
{
    [SerializeField] GameObject logOne;
    [SerializeField] GameObject logTwo;

    [SerializeField] float m_splitThreshold=2f;
    [SerializeField] float m_stickThreshold=1f;

    Collider m_collider = null;

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

        Split(blade); 

    }

    private void Split(Blade blade)
    {
        //Split Log
        float bladeHitSpeed = blade.m_controllerDataReader.Velocity.magnitude;
        
        if (bladeHitSpeed > m_splitThreshold)
        {
            
            m_collider.enabled = false;//Disable collision so we can only split once

            EnablePhysics(logOne);
            EnablePhysics(logTwo);
        }

        //Stick Axe
        else if (bladeHitSpeed > m_stickThreshold)
        {
            blade.Drop();
            blade.DisablePhysics();
        }
    }

     void EnablePhysics(GameObject log)
    {
        log.transform.parent = null;

        Rigidbody rg = log.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.isKinematic = false;
    }
        
}

