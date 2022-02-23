using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    private GameManager gM;
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float floatSpeed = 2f;
        float rotSpeed = 20f;
        float sinYPos = Mathf.Sin(Time.time * floatSpeed) / 500f;
        float YPos = transform.position.y;
        float newY = sinYPos + YPos;

        transform.position = new Vector3(pos.x, newY, pos.z);
        transform.Rotate(Time.deltaTime * rotSpeed, 0, 0, Space.Self); 
    }
}
