using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperPickUp : GazeManager
{
    [SerializeField]
    private int newspaperIndex;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        gM.PickUpNewsPaper(newspaperIndex);
        Destroy(gameObject);
    }
}
