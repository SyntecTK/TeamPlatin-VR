using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionBehaviour : MonoBehaviour
{
    Rigidbody rbBlockO;

    void Start()
    {
        rbBlockO = GameObject.Find("Block_O").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision Check");
        Debug.Log("Collided with: " + other.gameObject.name);
        if(other.gameObject.name == "Shelf_Blue")
        {
            rbBlockO.AddForce(Vector3.back * 200);
            Debug.Log("BlockPushed Check");
        }
    }
}
