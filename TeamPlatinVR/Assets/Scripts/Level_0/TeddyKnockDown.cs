using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyKnockDown : GazeManager
{
    [SerializeField]
    private float pushStrength = 2f;

    private Rigidbody rbTeddy;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        Rigidbody rbTeddy = gameObject.GetComponent<Rigidbody>();
        rbTeddy.AddForce(transform.forward * pushStrength * -1);
    }
}
