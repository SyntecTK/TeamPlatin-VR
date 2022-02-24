using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRattle : GazeManager
{
    private AudioSource audio;

    public override void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void ChangeOnGaze()
    {
        audio.Play();
    }
}
