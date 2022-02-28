using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodestBehaviours : GazeManager
{
    private Transform chestTop;
    private GameObject portraitImage;
    private GameObject gears;

    public override void Start()
    {
        base.Start();
        chestTop = GameObject.Find("Chest_Top").GetComponent<Transform>();
        portraitImage = GameObject.Find("Portrait_Bild");
        gears = GameObject.Find("Gears");
    }

    public override void ChangeOnGaze()
    {
        switch(this.name)
        {
            case "Podest_N":
                if(gM.IsBlockPickedUp(0))
                {
                    gM.PlaceBlocks(0);
                    PlaceBlock();
                }
                break;
            case "Podest_O":
                if(gM.IsBlockPickedUp(1))
                {
                    gM.PlaceBlocks(1);
                    PlaceBlock();
                }
                break;
            case "Podest_A":
                if(gM.IsBlockPickedUp(2))
                {
                    gM.PlaceBlocks(2);
                    PlaceBlock();
                }
                break;
            case "Podest_H":
                if(gM.IsBlockPickedUp(3))
                {
                    gM.PlaceBlocks(3);
                    PlaceBlock();
                }
                break;
        }
        if(gM.CheckBlockPuzzle())
        {
            chestTop.Rotate(new Vector3(0, 0, 50));
            chestTop.GetComponent<AudioSource>().Play();
            portraitImage.GetComponent<MeshRenderer>().enabled = true;
            portraitImage.GetComponent<MeshCollider>().enabled = true;
            gears.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void PlaceBlock()
    {
        GameObject block = transform.GetChild(0).gameObject;
        GetComponent<AudioSource>().Play();
        block.SetActive(true);
        gameObject.layer = 0;
    }
}
