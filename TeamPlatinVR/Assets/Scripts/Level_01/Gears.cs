using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : GazeManager
{
    private GameObject portraitImage;
    public override void Start()
    {
        base.Start();
        portraitImage = GameObject.Find("Portrait_Bild");
    }

    public override void ChangeOnGaze()
    {
        gM.PickUpGears();
        GetComponent<AudioSource>().Play();
        GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
        portraitImage.GetComponent<MeshRenderer>().enabled = true;
        portraitImage.GetComponent<BoxCollider>().enabled = true;
        gM.NextGameState();
    }

}
