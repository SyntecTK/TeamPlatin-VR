using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyCollectible : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        gM.PickUpTeddy();
        GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
