using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        gM.MovePlayer(this.transform.position);
        GetComponent<AudioSource>().Play();
    }

}
