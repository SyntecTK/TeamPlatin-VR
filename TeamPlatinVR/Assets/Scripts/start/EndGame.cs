using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : GazeManager
{
    public override void ChangeOnGaze()
    {
        Application.Quit();
    }
}
