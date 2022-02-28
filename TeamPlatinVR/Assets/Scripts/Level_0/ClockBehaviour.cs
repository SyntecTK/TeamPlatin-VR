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
    private AudioClip breakSound;
    [SerializeField]
    private Material newSkybox;
    public GameObject brokenGears;
    private GameObject clockGearSmall;
    private GameObject clockGearBig;

    public override void Start()
    {
        base.Start();
        clock_hand_long = GameObject.Find("Big_Pointer");
        clock_hand_short = GameObject.Find("Small_Pointer");
        clockGearBig = GameObject.Find("Clock_Gear01");
        clockGearSmall = GameObject.Find("Clock_Gear02");
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
            StartCoroutine(PlaySounds());
        }
    }

    IEnumerator PlaySounds()
    {
        clockGearSmall.GetComponent<MeshRenderer>().enabled = false;
        clockGearSmall.GetComponent<MeshCollider>().enabled = false;
        clockGearBig.GetComponent<MeshRenderer>().enabled = false;
        clockGearBig.GetComponent<MeshCollider>().enabled = false;
        GetComponent<AudioSource>().clip = breakSound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        gM.FirstPuzzleWin(winSound, newSkybox);
    }

}
