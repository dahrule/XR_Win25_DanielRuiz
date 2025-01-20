using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRGrabInteractable))]
public class Blade : MonoBehaviour
{
    public XRGrabInteractable m_grabInteractable;
    public ControllerDataReader m_controllerDataReader;
    XRBaseInteractor m_interactor;


    
    void Awake()
    {
        m_grabInteractable=GetComponent<XRGrabInteractable>();  
    }


    private void OnEnable()
    {
        if (m_grabInteractable == null)
            return;

        m_grabInteractable.selectEntered.AddListener(OnSelectEnter);
        m_grabInteractable.selectExited.AddListener(ResetControllerDataReader);
    }

    private void ResetControllerDataReader(SelectExitEventArgs arg0)
    {
        m_controllerDataReader = null;
    }

    private void OnSelectEnter(SelectEnterEventArgs arg)
    {
        //Set te interactor that is grabbing the axe
        m_interactor = arg.interactorObject as XRBaseInteractor;

        //Set the ControllerDataReader
        m_controllerDataReader=m_interactor.gameObject.GetComponentInParent<ControllerDataReader>();

    }

    private void OnDisable()
    {
        if (m_grabInteractable == null)
            return;

        m_grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
        m_grabInteractable.selectExited.RemoveListener(ResetControllerDataReader);
    }
}
