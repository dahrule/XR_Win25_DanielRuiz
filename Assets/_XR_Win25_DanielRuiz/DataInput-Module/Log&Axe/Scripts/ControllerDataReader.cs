using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script is in charge of reading data from the touch  controller
/// </summary>
public class ControllerDataReader : MonoBehaviour
{
    [SerializeField] InputActionProperty velocityProperty;

  /// <summary>
  /// This is a Property
  /// </summary>
    public Vector3 Velocity { get; private set; } = Vector3.zero;


 
    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        //Debug.Log("Velocity: " + Velocity);
    }
}
