using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBehaviour : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(DisableHitbox());
    }

    IEnumerator DisableHitbox()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(3);
        GetComponent<BoxCollider>().enabled = true;
    }
}
