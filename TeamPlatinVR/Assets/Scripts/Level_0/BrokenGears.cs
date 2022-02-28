using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGears : MonoBehaviour
{
    private GameManager gM;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gM.GameState() == 1)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    
}
