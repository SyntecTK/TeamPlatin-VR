using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackBoxBehaviour : GazeManager
{
    private bool rotating;
    private int spins;

    public override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        if(rotating)
        {
            Transform handle = GameObject.Find("jackbox-handle").GetComponent<Transform>();
            handle.Rotate(2f, 0, 0, Space.Self);
        }
    }

    public override void ChangeOnGaze()
    {
        Transform jbHandle = gameObject.transform.GetChild(1);
        Transform jbTop = gameObject.transform.GetChild(2);
        StartCoroutine(SpinHandle(jbHandle, jbTop, spins));
        GetComponent<AudioSource>().Play();
        spins++;
        if(spins >= 3)
        {
            gameObject.layer = 0;  
        }
    }

    IEnumerator SpinHandle(Transform handle, Transform top, int spins)
    {
        rotating = true;
        gameObject.layer = 1;
        yield return new WaitForSeconds(4);
        rotating = false;
        gameObject.layer = 6;
        if(spins == 2)
        {
            top.Rotate(0, 0, 75);
            GameObject blockN = transform.GetChild(3).gameObject;
            blockN.GetComponent<MeshRenderer>().enabled = true;
            blockN.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
