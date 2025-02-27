using System;
using UnityEngine;
using UnityEngine.Events;


public class StoneSocket : MonoBehaviour
{
    [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
                                                                //[SerializeField] private GameObject stoneReference;
    [SerializeField] string stoneTag;
     bool isOccupied = false;

    public static int numberOfStonesPlaced = 0;


    #region Events

    public static event Action<StoneSocket,float> OnAllStonesPlaced;

    [SerializeField] UnityEvent sampleUnityEvent;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(stoneTag))
        {
            isOccupied = true;
            //numberOfStonesPlaced = numberOfStonesPlaced + 1; //Same as line below 
            numberOfStonesPlaced++;
            
            if (numberOfStonesPlaced==3)
            {
                 OnAllStonesPlaced?.Invoke(this,2.0f);
            }

            if (numberOfStonesPlaced == 1)
            {
                sampleUnityEvent?.Invoke();
            }

            Debug.Log($"{numberOfStonesPlaced} number of stones placed");
            Debug.Log($"{other.gameObject.name} gameobject entered the trigger");
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(stoneTag))
        {
            isOccupied = false;
            numberOfStonesPlaced--;

            Debug.Log($"{numberOfStonesPlaced} number of stones placed");
            Debug.Log($"{other.gameObject.name} gameobject entered the trigger");
        }
    }
}


