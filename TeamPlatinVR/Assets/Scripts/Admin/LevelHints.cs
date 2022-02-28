using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHints : MonoBehaviour
{
    private GameObject teddy;
    private GameObject poster;

    private GameManager gM;

    private void Awake()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        teddy = transform.GetChild(0).gameObject;
        poster = transform.GetChild(0).gameObject;
        teddy = transform.GetChild(0).gameObject;

        switch(gM.GameState())
        {
            case 0:
                poster.SetActive(false);
                teddy.SetActive(true);
                break;
            case 1:
                poster.SetActive(true);
                teddy.SetActive(false);
                break;
        }
    }
}
