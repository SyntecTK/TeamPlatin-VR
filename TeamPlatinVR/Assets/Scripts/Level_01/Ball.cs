using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : GazeManager
{
    private GameObject blockO;
    private Rigidbody rbBlockO;

    public override void Start()
    {
        base.Start();
        blockO = GameObject.Find("Block_O");
        rbBlockO = blockO.GetComponent<Rigidbody>();
    }

    public override void ChangeOnGaze()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 500);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "DrawerBlue")
        {
            blockO.layer = 6;
            rbBlockO.AddForce(Vector3.back * 200);
            GetComponent<AudioSource>().Play();
        }
    }
}
