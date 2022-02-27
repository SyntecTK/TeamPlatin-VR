using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeLamp : GazeManager
{
    private Light lampLight;
    private bool lightOn;

    public override void Start()
    {
        base.Start();
        lampLight = GameObject.Find("LampLight").GetComponent<Light>();
    }

    public override void ChangeOnGaze()
    {
        if(lightOn)
        {
            lampLight.enabled = false;
            GetComponent<AudioSource>().Play();
            lightOn = false;
        }
        else if(!lightOn)
        {
            lampLight.enabled = true;
            GetComponent<AudioSource>().Play();
            lightOn = true;
        } 
    }
}
