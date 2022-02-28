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
        GetComponent<AudioSource>().Play();
        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
