using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : GazeManager
{
    [SerializeField]
    private GameObject bigFlyer;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        bigFlyer.SetActive(true);
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
