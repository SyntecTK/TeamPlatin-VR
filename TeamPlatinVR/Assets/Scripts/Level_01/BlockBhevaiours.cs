using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBhevaiours : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        switch(this.name)
        {
            case "Block_N":
                //gM.pickUpBlock_N = true;
                gM.PickUpBlock(0);
                DisableBlock();
                break;
            case "Block_O":
                //gM.pickUpBlock_O = true;
                gM.PickUpBlock(1);
                DisableBlock();
                break;
            case "Block_A":
                //gM.pickUpBlock_A = true;
                gM.PickUpBlock(2);
                DisableBlock();
                break;
            case "Block_H":
                //gM.pickUpBlock_H = true;
                gM.PickUpBlock(3);
                DisableBlock();
                break;
        }
    }

    private void DisableBlock()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Debug.Log(this.name + " disabled");
    }
}
