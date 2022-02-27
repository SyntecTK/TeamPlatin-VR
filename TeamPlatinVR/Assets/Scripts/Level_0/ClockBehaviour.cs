using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockBehaviour : GazeManager
{
    private GameObject clock_hand_long;
    private GameObject clock_hand_short;

    [SerializeField]
    private AudioClip winSound;
    [SerializeField]
    private Material newSkybox;

    public override void Start()
    {
        base.Start();
        clock_hand_long = GameObject.Find("Big_Pointer");
        clock_hand_short = GameObject.Find("Small_Pointer");
    }

    public override void ChangeOnGaze()
    {
        Vector3 rotation = new Vector3(0, 0, 60.0f);
        switch(this.name)
        {
            case "Clock_Gear01":
                clock_hand_long.transform.Rotate(rotation, Space.Self);
                Debug.Log("Gear01 Rotation.z: " + clock_hand_long.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                CheckPuzzleWin();
                break;
            case "Clock_Gear02":
                clock_hand_short.transform.Rotate(rotation, Space.Self);
                Debug.Log("Gear02 Rotation.z: " + clock_hand_short.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                CheckPuzzleWin();
                break;
        }
    }

    private void CheckPuzzleWin()
    {
        if(clock_hand_long.transform.eulerAngles.z >= 80 && clock_hand_long.transform.eulerAngles.z <= 90 &&
        clock_hand_short.transform.eulerAngles.z >= 350 && clock_hand_short.transform.eulerAngles.z <= 360)
        {
            gM.FirstPuzzleWin(winSound, newSkybox);
        }
    }
}
