using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWalls : MonoBehaviour
{
    private GameManager gM;
    private float randomValue;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        randomValue = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gM.FloatAnimation(gameObject, 0.005f, randomValue, 0.1f);
    }
}
