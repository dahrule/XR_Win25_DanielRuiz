using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereBehaviour : MonoBehaviour
{
   /* [SerializeField] StoneSocket fireStoneSocket;
    [SerializeField] StoneSocket waterStoneSocket;
    [SerializeField] StoneSocket forestStoneSocket;*/


    private void OnEnable()
    {
        //Subscribing to events
        StoneSocket.OnAllStonesPlaced += Disappear;
        /*waterStoneSocket.OnAllStonesPlaced += Disappear;
        forestStoneSocket.OnAllStonesPlaced += Disappear;*/

    }

    private void OnDisable()
    {
        //UnSubscribing to events
        StoneSocket.OnAllStonesPlaced -= Disappear;
        /*waterStoneSocket.OnAllStonesPlaced -= Disappear;
        forestStoneSocket.OnAllStonesPlaced -= Disappear;*/

    }

    private void Disappear(StoneSocket socket, float arg2)
    {
        gameObject.SetActive(false);
    }

    public void PrintDebugMessage()
    {
        UnityEngine.Debug.Log("Dissapear functions is called");
    }


}
