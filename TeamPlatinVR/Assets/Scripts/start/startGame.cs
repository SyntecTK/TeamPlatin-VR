using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    public override void ChangeOnGaze()
    {
        Debug.Log("Game started");
    }
}
