using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private GameObject gazeObject;

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
    
        jbRotation = new Vector3(40, 0, 0);
        gazeObject = null;

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
            Debug.Log("Current Object: " + gazeObject.name);
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

    private void ManageJackBox()
    {
        Debug.Log("Gaze Object Name: " + gameObject.name);
        if(gazeObject.name == "jackBox")
        {
            jbHandle =  gazeObject.transform.GetChild(1);
            Debug.Log("Got Child: " + jbHandle.name);
            jbHandle.Rotate(jbRotation * Time.deltaTime, Space.Self);
        }
    }

    public void RotateObject(GameObject rotationObject, Vector3 rotation)
    {
        rotationObject.transform.Rotate(rotation * Time.deltaTime, Space.Self);
        
    }
}
