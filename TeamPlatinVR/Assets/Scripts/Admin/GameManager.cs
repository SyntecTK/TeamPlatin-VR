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
        
        jbHandle =  jackBox.transform.GetChild(1);
        Debug.Log("Found Child!" + jbHandle.name);
        jbRotation = new Vector3(10, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        jbHandle.Rotate(jbRotation * Time.deltaTime, Space.Self);
        Debug.Log("Rotation: " + jbHandle.eulerAngles);
    }

    private void SetGazedObject(GameObject obj)
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
        if(gazeObject.name == "jackBox_Handle")
        {

        }
    }

    public void RotateObject(GameObject rotationObject, Vector3 rotation)
    {
        rotationObject.transform.Rotate(rotation * Time.deltaTime, Space.Self);
    }
}
