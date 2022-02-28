using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWheel : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(DisableInteractionForSeconds(3));
    }

    IEnumerator DisableInteractionForSeconds(int seconds)
    {
        GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(seconds);
        GetComponent<MeshCollider>().enabled = true;
    }
}
