using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBreakSound : MonoBehaviour
{
    public Transform keyLocation;
    public GameObject key;

    private AudioSource audio;
    private int collidedObjects;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(collidedObjects == 0)
        {
            audio.Play();
            Instantiate(key, keyLocation.position, keyLocation.rotation);
        }
        collidedObjects++;
    }
}
