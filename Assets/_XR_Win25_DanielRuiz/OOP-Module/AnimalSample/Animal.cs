using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public string Name;

  public virtual void MakeSound()
    {
        Debug.Log("aNIMAL MAKES SOUND");
    }
}
