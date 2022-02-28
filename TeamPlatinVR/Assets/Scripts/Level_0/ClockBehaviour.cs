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
    private AudioClip repairSound;
    [SerializeField]
    private Material morningSkybox;
    [SerializeField]
    private Material nightSkybox;
    public GameObject brokenGears;
    private GameObject clockGearSmall;
    private GameObject clockGearBig;
    private bool clockRepaired;
    public GameObject kinderGears;
    private AudioClip gearTurn;

    public override void Start()
    {
        base.Start();
        clock_hand_long = GameObject.Find("Big_Pointer");
        clock_hand_short = GameObject.Find("Small_Pointer");
        clockGearBig = GameObject.Find("Clock_Gear01");
        clockGearSmall = GameObject.Find("Clock_Gear02");
        gearTurn = GetComponent<AudioSource>().clip;
        if (gM.GameState() >= 1)
        {
            //GetComponent<MeshRenderer>().enabled = false;
            SwitchGears();
        }
        if(gM.GameState() >= 2)
        {
            kinderGears.SetActive(true);
        }
        Debug.Log("GameState "+gM.GameState());
    }

    public override void ChangeOnGaze()
    {
        Vector3 rotationBig = new Vector3(0, 0, 60.0f);
        Vector3 rotationSmall = new Vector3(0, 0, 30.0f);
        if (gM.GameState() == 1)
        {
            if (!clockRepaired)
            {
                kinderGears.SetActive(true);
                GetComponent<AudioSource>().clip = repairSound;
                GetComponent<AudioSource>().Play();
                clockRepaired = true;
            }
            else
            {
                GetComponent<AudioSource>().clip = gearTurn;
                MoveClockPointers(rotationBig, rotationSmall);
            }

        }
        else
        {
            MoveClockPointers(rotationBig, rotationSmall);

            Debug.Log("Großer Zeiger z: " + clock_hand_long.transform.eulerAngles.z);
            Debug.Log("Kleiner Zeiger z: " + clock_hand_short.transform.eulerAngles.z);
        }
    }

    private void CheckPuzzleWin()
    {
        if (gM.GameState() == 0)
        {
            if (clock_hand_long.transform.eulerAngles.z >= 80 && clock_hand_long.transform.eulerAngles.z <= 90 &&
            clock_hand_short.transform.eulerAngles.z >= 350 && clock_hand_short.transform.eulerAngles.z <= 360)
            {
                SwitchGears();
                StartCoroutine(PlaySounds());
            }
        }
        else if (gM.GameState() == 1)
        {
            if (clock_hand_long.transform.eulerAngles.z >= 145 && clock_hand_long.transform.eulerAngles.z <= 155 &&
            clock_hand_short.transform.eulerAngles.z >= 145 && clock_hand_short.transform.eulerAngles.z <= 155)
            {
                gM.FirstPuzzleWin(winSound, nightSkybox);
            }
        }
        else if (gM.GameState() == 2)
        {
            if (clock_hand_long.transform.eulerAngles.z >= 205 && clock_hand_long.transform.eulerAngles.z <= 210 &&
            clock_hand_short.transform.eulerAngles.z >= 325 && clock_hand_short.transform.eulerAngles.z <= 335)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

    private void MoveClockPointers(Vector3 rotBig, Vector3 rotSmall)
    {
        switch (this.name)
        {
            case "Clock_Gear01":
                clock_hand_long.transform.Rotate(rotBig, Space.Self);
                Debug.Log("Gear01 Rotation.z: " + clock_hand_long.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                CheckPuzzleWin();
                break;
            case "Clock_Gear02":
                clock_hand_short.transform.Rotate(rotSmall, Space.Self);
                Debug.Log("Gear02 Rotation.z: " + clock_hand_short.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                CheckPuzzleWin();
                break;
        }
    }

    private void SwitchGears()
    {
        brokenGears.GetComponent<MeshRenderer>().enabled = true;
        clockGearSmall.GetComponent<MeshRenderer>().enabled = false;
        clockGearBig.GetComponent<MeshRenderer>().enabled = false;
        
        if(gM.GameState() == 0)
        {
            clockGearBig.GetComponent<MeshCollider>().enabled = false;
            clockGearSmall.GetComponent<MeshCollider>().enabled = false;
        }
    }

    IEnumerator PlaySounds()
    {
        GetComponent<AudioSource>().clip = breakSound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        gM.FirstPuzzleWin(winSound, morningSkybox);
    }

    IEnumerator LoadLastLevel()
    {
        gM.FirstPuzzleWin(winSound, nightSkybox);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }
}
