using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //Drawers
    bool drawerBluePushed;
    bool drawerWhitePushed;
    bool drawerGreenPushed;
    Vector3 endPos;
    public float duration;

    //JackBox
    Vector3 rotation = new Vector3(0, 0, 60.0f);

    //Puzzle
    bool teddyCollected;
    bool isRotating;


    private float pushStrength;
    private bool gaze;
    private float timer;
    private bool puzzleSolved;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        //Fix Renderer to only search on Buttons
        //baseColor = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        radio = GetComponentInParent<AudioSource>();

        lightOn = false;

        //Wenn man im ersten Level ist werden diese Objekte gesucht und variablen gesetzt
        if(SceneManager.GetActiveScene().name == "Level_0")
        {
            pointer = GameObject.Find("Pointer");
            pointerStartPos = pointer.transform.position;
            clock_hand_long = GameObject.Find("Big_Pointer");
            chl_startRot = clock_hand_long.transform.rotation;
            clock_hand_short = GameObject.Find("Small_Pointer");
            chs_startRot = clock_hand_short.transform.rotation;
        }
        

        puzzleSolved = false;
        pushStrength = 1000f;

        drawerBluePushed = false;
        drawerGreenPushed = false;
        drawerWhitePushed = false;


        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gaze==true)
        {
            if(duration > timer)
            {
                    timer += Time.deltaTime;
                    gazeImage.fillAmount = timer / duration;
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
        //TO-DO change to this.name
        switch(this.tag)
        {
            //Level_0 Objects------------------------------------------------
            case "Teddy":
                Rigidbody rbTeddy = gameObject.GetComponent<Rigidbody>();
                rbTeddy.AddForce(transform.forward * pushStrength * -1);
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
                    GetComponent<AudioSource>().Play();
                    lightOn = false;
                }
                else if(!lightOn)
                {
                    GetComponentInChildren<Light>().enabled = true;
                    GetComponent<AudioSource>().Play();
                    lightOn = true;
                } 
                break;
                
            //Level_1 Objects----------------------------------------------------------------
            case "Drawer":
                Vector3 startPos = transform.position;
                switch(this.name)
                {
                    case "DrawerBlue":
                        if(!drawerBluePushed)
                        {
                            MoveDrawer(startPos, new Vector3(0, 0, -1), 0.5f);
                            GetComponent<AudioSource>().Play();
                            drawerBluePushed = true;
                        }else{
                            MoveDrawer(startPos, new Vector3(0, 0, 1), 0.5f);
                            drawerBluePushed = false;
                        }
                    break;
                    case "DrawerGreen":
                        if(!drawerGreenPushed)
                        {
                            MoveDrawer(startPos, new Vector3(0, 0, 1), 0.4f);
                            GetComponent<AudioSource>().Play();
                            drawerGreenPushed = true;
                        }else{
                            MoveDrawer(startPos, new Vector3(0, 0, -1), 0.4f);
                            drawerGreenPushed = false;
                        }
                        break;
                    case "DrawerWhite":
                        if(!drawerWhitePushed && gM.teddyCollected)
                        {
                            GameObject ted = GameObject.Find("BlockTeddy02");
                            ted.GetComponent<MeshRenderer>().enabled = true;
                            MoveDrawer(startPos, new Vector3(-1, 0, 0), 0.4f);
                            GetComponent<AudioSource>().Play();
                            drawerWhitePushed = true;
                        }else if (drawerWhitePushed){
                            MoveDrawer(startPos, new Vector3(1, 0, 0), 0.4f);
                            drawerWhitePushed = false;
                        }
                        break;
                }
            break;
            case "Block_N":
                gM.pickUpBlock_N = true;
                gameObject.SetActive(false);
                break;
            case "Block_O":
                gM.pickUpBlock_O = true;
                gameObject.SetActive(false);
                break;
            case "Block_A":
                gM.pickUpBlock_A = true;
                gameObject.SetActive(false);
                break;
            case "Block_H":
                gM.pickUpBlock_H = true;
                gameObject.SetActive(false);
                break;
            case "Podest_N":
                if(gM.pickUpBlock_N)
                {
                    GameObject block = transform.GetChild(0).gameObject;
                    GetComponent<AudioSource>().Play();
                    block.SetActive(true);
                    gameObject.layer = 0;
                    gM.placedBlock_N = true;
                    gM.CheckBlockPuzzle();
                }
                break;
            case "Podest_O":
                if(gM.pickUpBlock_O)
                {
                    GameObject block = transform.GetChild(0).gameObject;
                    GetComponent<AudioSource>().Play();
                    block.SetActive(true);
                    gameObject.layer = 0;
                    gM.placedBlock_O = true;
                    gM.CheckBlockPuzzle();
                }
                break;
            case "Podest_A":
                if(gM.pickUpBlock_A)
                {
                    GameObject block = transform.GetChild(0).gameObject;
                    GetComponent<AudioSource>().Play();
                    block.SetActive(true);
                    gameObject.layer = 0;
                    gM.placedBlock_A = true;
                    gM.CheckBlockPuzzle();
                }
                break;
            case "Podest_H":
                if(gM.pickUpBlock_H)
                {
                    GameObject block = transform.GetChild(0).gameObject;
                    GetComponent<AudioSource>().Play();
                    block.SetActive(true);
                    gameObject.layer = 0;
                    gM.placedBlock_H = true;
                    gM.CheckBlockPuzzle();
                }
                break;
            case "SpielzeugBall":
                Rigidbody rb=gameObject.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.forward * 500);
                break;
            case "BlockTeddy":
                gM.teddyCollected = true;
                gameObject.SetActive(false);
                GetComponent<AudioSource>().Play();
                break;
            case "JackBox":
                Transform jbHandle = gameObject.transform.GetChild(1);
                Transform jbTop = gameObject.transform.GetChild(2);
                StartCoroutine(SpinHandle(jbHandle, jbTop, gM.spins));
                GetComponent<AudioSource>().Play();
                gM.spins++;
                if(gM.spins >= 3)
                {
                    gameObject.layer = 0;  
                }
                break;
        }
    }

    IEnumerator SpinHandle(Transform handle, Transform top, int spins)
    {
        gM.rotating = true;
        gameObject.layer = 1;
        yield return new WaitForSeconds(4);
        gM.rotating = false;
        gameObject.layer = 6;
        if(spins == 2)
        {
            top.Rotate(0, 0, 75);
            GameObject blockN = transform.GetChild(3).gameObject;
            blockN.GetComponent<MeshRenderer>().enabled = true;
            blockN.GetComponent<BoxCollider>().enabled = true;
        }
            
    }

    private void MoveDrawer(Vector3 startPos, Vector3 offSet, float distance)
    {
        Vector3 endPos = new Vector3(startPos.x + offSet.x, startPos.y + offSet.y, startPos.z + offSet.z);
        transform.position = Vector3.MoveTowards(startPos, endPos, distance);
    }

    private void RotateObject()
    {
        Vector3 rotation = new Vector3(5, 0, 0);
        GameObject jackBox = GameObject.Find("jackbox-handle");

        
        //Debug.Log("jackBoxhandle Rotation.z: " + jackBox.transform.eulerAngles.z);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jackBox.transform.Rotate(rotation * Time.deltaTime, Space.Self);
            Debug.Log("Rotated");
        }
    }

    public void ChangeOffGaze()
    {
        if(gaze)
        {
            gaze = false;
            gazeImage.fillAmount = 0;
            gM.SetGazedObject(null);
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

    private void OnCollisionEnter(Collision other) {
        if(this.gameObject.name == "SpielzeugBall" && other.gameObject.name == "DrawerBlue")
        {
            Debug.Log("Collided with Shelf");
            GameObject blockO = GameObject.Find("Block_O");
            Rigidbody rbBlock = blockO.GetComponent<Rigidbody>();
            blockO.layer = 6;
            rbBlock.AddForce(Vector3.back * 200);
            GetComponent<AudioSource>().Play();

            //Spielt gleichzeitig mit ^
            //Überspielt den anderen Sound und ist maybe zu lang
            //blockO.GetComponent<AudioSource>().Play();
        }
    }
}
