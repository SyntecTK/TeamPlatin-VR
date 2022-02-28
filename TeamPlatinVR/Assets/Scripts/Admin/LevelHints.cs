using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHints : MonoBehaviour
{
    private GameObject teddy;
    private GameObject poster;
    private GameObject snowman;

    private GameManager gM;

    private void Awake()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        teddy = transform.GetChild(0).gameObject;
        poster = transform.GetChild(1).gameObject;
        snowman = transform.GetChild(2).gameObject;

        switch(gM.GameState())
        {
            case 0:
                poster.SetActive(false);
                teddy.SetActive(true);
                snowman.SetActive(false);
                break;
            case 1:
                poster.SetActive(true);
                teddy.SetActive(false);
                snowman.SetActive(false);
                break;
            case 2:
                poster.SetActive(false);
                teddy.SetActive(false);
                snowman.SetActive(true);
                break;

        }
    }
}
