using UnityEngine;

public class Snake : Animal
{
    Color Color = Color.white;

    private void Start()
    {
        Name = "Snake";
    }

   public override void MakeSound()
    {
        Debug.Log("Snake hisses");
    }
}
