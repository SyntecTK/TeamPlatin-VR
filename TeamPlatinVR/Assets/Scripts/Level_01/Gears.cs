using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        gM.PickUpGears();
        GetComponent<AudioSource>().Play();
        GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
    }

}
