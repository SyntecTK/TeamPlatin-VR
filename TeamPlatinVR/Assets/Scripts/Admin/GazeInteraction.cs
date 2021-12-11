using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInteraction : MonoBehaviour
{
    public Image gazeImage;
    public Color usedButton;
    public Material portraitMaterial;
    public Material newSkybox;
    public AudioClip winSound;

    public AudioClip moveSound;

    public AudioClip radio01;
    public AudioClip radio02;
    public AudioClip radio03;
    public AudioClip radio04;
    public AudioClip radio05;

    private Color baseColor;
    private GameManager gameManager;
    //Clock
    private GameObject clock_hand_long;
    private GameObject clock_hand_short;
    private Quaternion chl_startRot;
    private Quaternion chs_startRot;

    //Teddy
    private Rigidbody rb;

    //Radio
    private GameObject pointer;
    private Vector3 pointerStartPos;
    private AudioSource radio;

    //Lampe
    bool lightOn;

    public float duration;

    private float pushStrength;
    private bool gaze;
    private float timer;
    private bool puzzleSolved;

    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        radio = GetComponentInParent<AudioSource>();
        
        pointer = GameObject.Find("Pointer");
        pointerStartPos = pointer.transform.position;

        lightOn = false;

        clock_hand_long = GameObject.Find("Big_Pointer");
        chl_startRot = clock_hand_long.transform.rotation;
        clock_hand_short = GameObject.Find("Small_Pointer");
        chs_startRot = clock_hand_short.transform.rotation;

        puzzleSolved = false;
        pushStrength = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gaze==true)
        {
            if(duration > timer) {
                {
                    timer += Time.deltaTime;
                    gazeImage.fillAmount = timer / duration;
                }
            }else{
                timer = 0;
                ChangeOnGaze();
                gaze = false;
                gazeImage.fillAmount = 0;
            }
        }
    }

    public void ChangeOnGaze()
    {
        Vector3 rotation = new Vector3(0, 0, 60.0f);
        switch(this.tag)
        {
            case "Teddy":
                rb.AddForce(transform.forward * pushStrength * -1);
                break;
            case "MovePoint":
                gameManager.MovePlayer(this.transform.position);
                GetComponent<AudioSource>().Play();
                break;
            case "Button": 
                StartCoroutine(ChangeButtonColor());
                switch (this.name)
                {
                    case "Button":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0);
                        radio.Stop();
                        radio.clip = radio01;
                        radio.Play();
                        break;
                    case "Button 2":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.03f);
                        radio.Stop();
                        radio.clip = radio02;
                        radio.Play();
                        break;
                    case "Button 3":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.06f);
                        radio.Stop();
                        radio.clip = radio03;
                        radio.Play();
                        break;
                    case "Button 4":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.09f);
                        radio.Stop();
                        radio.clip = radio04;
                        radio.Play();
                        break;
                    case "Button 5":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.12f);
                        radio.Stop();
                        radio.clip = radio05;
                        radio.Play();
                        break;
                }
                break;
            case "Clock_Gear01":
                clock_hand_long.transform.Rotate(rotation, Space.Self);
                Debug.Log("Gear01 Rotation.z: " + clock_hand_long.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                if(clock_hand_long.transform.eulerAngles.z >= 80 && clock_hand_long.transform.eulerAngles.z <= 90 &&
                clock_hand_short.transform.eulerAngles.z >= 350 && clock_hand_short.transform.eulerAngles.z <= 360)
                {
                    puzzleSolved = true;
                    CheckPuzzleStatus();
                }
                break;
            case "Clock_Gear02":
                clock_hand_short.transform.Rotate(rotation, Space.Self);
                Debug.Log("Gear02 Rotation.z: " + clock_hand_short.transform.eulerAngles.z);
                GetComponent<AudioSource>().Play();
                if(clock_hand_long.transform.eulerAngles.z >= 80 && clock_hand_long.transform.eulerAngles.z <= 90 &&
                clock_hand_short.transform.eulerAngles.z >= 350 && clock_hand_short.transform.eulerAngles.z <= 360)
                {
                    puzzleSolved = true;
                    CheckPuzzleStatus();
                }
                break;
            case "Portrait":
                //
                break;
            case "Lamp":
                if(lightOn)
                {
                    GetComponentInChildren<Light>().enabled = false;
                    lightOn = false;
                }
                else if(!lightOn)
                {
                    GetComponentInChildren<Light>().enabled = true;
                    lightOn = true;
                }
                    
                break;
        }
        

    }

    public void ChangeOffGaze()
    {
        if(gaze)
        {
            gaze = false;
            gazeImage.fillAmount = 0;
        }
    }

    public void StartCount()
    {
        timer = 0;
        gaze = true;
    }

    IEnumerator ChangeButtonColor()
    {
        GetComponent<Renderer>().material.color = usedButton;
        yield return new WaitForSeconds(3);
        GetComponent<Renderer>().material.color = baseColor;
    }

    private void CheckPuzzleStatus()
    {
        if(puzzleSolved)
        {
            GameObject.Find("Portrait").GetComponent<Renderer>().material = portraitMaterial;
            GameObject.Find("Portrait").GetComponent<AudioSource>().Play();
            GameObject.Find("Portrait").GetComponent<BoxCollider>().enabled = true;

            AudioSource clockSounds = GameObject.Find("Grandfather-Clock").GetComponent<AudioSource>();
            clockSounds.loop = false;
            clockSounds.clip = winSound;
            clockSounds.Play();

            RenderSettings.skybox = newSkybox;
        }
    }
}
