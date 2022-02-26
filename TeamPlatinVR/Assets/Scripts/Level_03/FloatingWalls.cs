using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWalls : MonoBehaviour
{
    private GameManager gM;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gM.FloatAnimation(gameObject, 1000f, 2f, 0.1f);
    }
}
