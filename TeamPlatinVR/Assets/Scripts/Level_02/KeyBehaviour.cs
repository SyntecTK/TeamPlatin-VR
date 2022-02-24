using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehaviour : GazeManager
{
    private AudioSource winSound;

    public override void Start()
    {
        base.Start();
        gazeImage = GameObject.Find("Image").GetComponent<Image>();
        duration = 1;
        winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        FloatAnimation();
    }

    public override void ChangeOnGaze()
    {
        GameObject.Find("Portrait_Bild").GetComponent<MeshRenderer>().enabled = true;
        gM.KeyCollected();
        winSound.Play();
        Destroy(gameObject);
    }

    private void FloatAnimation()
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
