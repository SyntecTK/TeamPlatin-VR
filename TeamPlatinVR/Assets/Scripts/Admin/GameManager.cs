using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Interactables
    public GameObject jackBox;
        private Transform jbHandle;
        private Vector3 jbRotation;


    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        playerPos = player.transform.position;
    
        jbRotation = new Vector3(100, 0, 0);
        gazeObject = null;

        rotating = false;

        rbBlock = GameObject.Find("Block_O").GetComponent<Rigidbody>();

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
            //handle.rotation = Quaternion.Euler(new Vector3(handle.eulerAngles.x * Time.deltaTime, 0, 0));
            handle.Rotate(0.2f, 0, 0, Space.Self);

        }
    }

    public void SetGazedObject(GameObject obj)
    {
        gazeObject = obj;
    }

    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y - 1, location.z);
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
    
    IEnumerator RotationTime(int delay)
    {
        rotating = true;
        yield return new WaitForSeconds(delay);
        rotating = false;
    }
}
