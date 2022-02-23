using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShatter : MonoBehaviour
{
    public GameObject destroyedObject;
    private GameManager gM;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        if(gM.destroyDiscoball)
        {
            Instantiate(destroyedObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
