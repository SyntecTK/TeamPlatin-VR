using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomLamps : GazeManager
{
    private bool lightOn;
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        if(lightOn)
        {
            GetComponentInChildren<Light>().enabled = false;
            GetComponent<AudioSource>().Play();
            lightOn = false;
        }
        else if(!lightOn)
        {
            GetComponentInChildren<Light>().enabled = true;
            GetComponent<AudioSource>().Play();
            lightOn = true;
        } 
    }
}
