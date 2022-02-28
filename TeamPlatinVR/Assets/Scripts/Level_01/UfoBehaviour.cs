using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBehaviour : GazeManager
{
    private FloatingWalls floatingScript;
    public override void Start()
    {
        base.Start();
        floatingScript = GetComponent<FloatingWalls>();
    }

    public override void ChangeOnGaze()
    {
        GetComponent<AudioSource>().Play();
        floatingScript.enabled = true;
    }
}
