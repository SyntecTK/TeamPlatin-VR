using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperBehaviour : GazeManager
{
    private bool[] newspaperPieces;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        newspaperPieces = gM.GetNewsPaperPieces();
        for(int i = 0; i < newspaperPieces.Length; i++)
        {
            if(newspaperPieces[i])
            {
                transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                GetComponent<AudioSource>().Play();
            }
                
        }
    }
    
}
