using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperBehaviour : GazeManager
{
    private bool[] newspaperPieces;

    [SerializeField]
    private GameObject finalIsland;
    [SerializeField]
    private GameObject bigPaper;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        newspaperPieces = gM.GetNewsPaperPieces();
        for(int i = 0; i < newspaperPieces.Length; i++)
        {
            if(newspaperPieces[i])
            {
                transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                GetComponent<AudioSource>().Play();
            } 
        }
        if(AllPiecesCollected())
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(SpawnNewIslandAndBigPaper());
        }
    }

    private bool AllPiecesCollected()
    {
        for(int i = 0; i < newspaperPieces.Length; i++)
        {
            if(newspaperPieces[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnNewIslandAndBigPaper()
    {
        finalIsland.SetActive(true);
        bigPaper.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
