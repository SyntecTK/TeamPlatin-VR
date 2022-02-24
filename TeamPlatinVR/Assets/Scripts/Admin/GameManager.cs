using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private GameObject gazeObject;

    private Rigidbody rbBlock;

    [HideInInspector]
    public bool teddyCollected;

    //JackBox
    public bool rotating;
    public int spins = 0;

    //Block Interactions
    public bool pickUpBlock_N;
    public bool pickUpBlock_O;
    public bool pickUpBlock_A;
    public bool pickUpBlock_H;

    public bool placedBlock_N;
    public bool placedBlock_O;
    public bool placedBlock_A;
    public bool placedBlock_H;

    //Interactables
    public GameObject jackBox;
        private Transform jbHandle;
        private Vector3 jbRotation;

    //Chest
    private Transform chestTop;

    //Spotlight List
    private bool[] spotlightArray = new bool[4];

    public bool destroyDiscoball;

    private bool keyCollected;


    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        playerPos = player.transform.position;

        playerPos = new Vector3(playerPos.x, playerPos.y - 1.5f, playerPos.z);
    
        jbRotation = new Vector3(100, 0, 0);
        gazeObject = null;

        rotating = false;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            rbBlock = GameObject.Find("Block_O").GetComponent<Rigidbody>();
            chestTop = GameObject.Find("Chest_Top").GetComponent<Transform>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(gazeObject != null)
        {
            ManageJackBox();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            //Debug.Log("Current Object: " + gazeObject.name);
            rbBlock.AddForce(Vector3.back * 200);
        }

        if(rotating)
        {
            Transform handle = GameObject.Find("jackbox-handle").GetComponent<Transform>();
            handle.Rotate(0.2f, 0, 0, Space.Self);
        }
    }

    public void CheckBlockPuzzle()
    {
        if(placedBlock_N && placedBlock_O && placedBlock_A && placedBlock_H)
        {
            chestTop.Rotate(new Vector3(0, 0, 50));
            chestTop.GetComponent<AudioSource>().Play();
            GameObject.Find("Portrait_Bild").GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void SetGazedObject(GameObject obj)
    {
        gazeObject = obj;
    }

    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y, location.z);
        playerPos = player.transform.position;
    }

    public void ManageJackBox()
    {
        Debug.Log("Gaze Object Name: " + gameObject.name);
        if(gazeObject.name == "jackBox")
        {
            jbHandle =  gazeObject.transform.GetChild(1);
            if(rotating)
                jbHandle.Rotate(jbRotation * Time.deltaTime, Space.Self);
        }
    }

    public void RotateObject(GameObject rotationObject, Vector3 rotation)
    {
        rotationObject.transform.Rotate(rotation * Time.deltaTime, Space.Self);
    }

    public void ObjectFloatAnimation(GameObject obj)
    {
         
    }
    
    IEnumerator RotationTime(int delay)
    {
        rotating = true;
        yield return new WaitForSeconds(delay);
        rotating = false;
    }

    public void SpotlightChecked(int spotlightIndex)
    {
        spotlightArray[spotlightIndex] = !spotlightArray[spotlightIndex];
    }

    public bool DiscoPuzzleWon()
    {
        for(int i = 0; i < spotlightArray.Length; i++)
        {
            if(spotlightArray[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void DestroyDiscoBall()
    {
        destroyDiscoball = true;
    }

    public void KeyCollected()
    {
        keyCollected = true;
    }
}
