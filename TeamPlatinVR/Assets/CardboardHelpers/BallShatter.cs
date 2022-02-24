using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShatter : MonoBehaviour
{
    public GameObject destroyedObject;
    private GameManager gM;

    private bool ballDropped;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gM.destroyDiscoball && !ballDropped)
        {
            StartCoroutine(DropDiscoball());
            ballDropped = true;
        }
    }

    IEnumerator DropDiscoball()
    {
        yield return new WaitForSeconds(2);
        Instantiate(destroyedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
