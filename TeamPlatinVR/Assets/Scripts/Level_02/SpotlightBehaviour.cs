using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightBehaviour : GazeManager
{
    private Material glassMat;
    private GameObject light;
    private GameObject number;

    private bool active;

    public override void Start()
    {
        glassMat = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        light = transform.GetChild(1).gameObject;
        number = transform.GetChild(2).gameObject;

        active = false;
    }

    public override void ChangeOnGaze()
    {
        if(!active)
        {
            glassMat.EnableKeyword("_EMISSION");
            light.SetActive(true);
            number.SetActive(true);
            active = true;
        }else{
            glassMat.DisableKeyword("_EMISSION");
            light.SetActive(false);
            number.SetActive(false);
            active = false;
        }
        GetComponent<AudioSource>().Play();
        
    }
}
