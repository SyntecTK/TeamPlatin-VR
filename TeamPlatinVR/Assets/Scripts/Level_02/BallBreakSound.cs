using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBreakSound : MonoBehaviour
{
    public Transform keyLocation;
    public GameObject key;

    private AudioSource breakSound;
    private int collidedObjects;

    void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(collidedObjects == 0)
        {
            breakSound.Play();
            Instantiate(key, keyLocation.position, key.transform.rotation);
        }
        collidedObjects++;
    }
}
