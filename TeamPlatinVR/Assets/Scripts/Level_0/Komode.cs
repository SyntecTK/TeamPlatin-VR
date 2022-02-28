using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komode : GazeManager
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 offSet;
    private float distance;
    private bool pushedOut;
    private AudioSource audioS;

    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closedSound;

    public override void Start()
    {
        base.Start();
        offSet = new Vector3(0, 0, 1);
        distance = 0.3f;
        audioS = GetComponent<AudioSource>();
    }

    public override void ChangeOnGaze()
    {
        startPos = transform.position;
        if(gM.GameState() == 2)
        {
            if (!pushedOut)
            {
                endPos = new Vector3(startPos.x + offSet.x, startPos.y + offSet.y, startPos.z + offSet.z);
                transform.position = Vector3.MoveTowards(startPos, endPos, distance);
                pushedOut = true;
            }
            else
            {
                endPos = new Vector3(startPos.x + (offSet.x * -1), startPos.y + (offSet.y * -1), startPos.z + (offSet.z * -1));
                transform.position = Vector3.MoveTowards(startPos, endPos, distance);
                pushedOut = false;
            }
            audioS.clip = openSound;
            audioS.Play();
        }else{
            audioS.clip = closedSound;
            audioS.Play();
        }
    }
}
