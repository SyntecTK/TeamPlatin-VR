using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitBehaviour : GazeManager
{
    private int sceneIndex;
    public GameObject loadingScreen;
    
    public override void Start()
    {
        base.Start();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public override void ChangeOnGaze()
    {
        if(sceneIndex == 1)
        {
            switch(gM.GameState())
            {
                case 0:
                    StartCoroutine(LoadNextScene(2));
                    break;
                case 1:
                    StartCoroutine(LoadNextScene(3));
                    break;
            }
            
        }else if(sceneIndex == 2)
        {
            StartCoroutine(LoadNextScene(1));
        }else if(sceneIndex == 3)
        {
            StartCoroutine(LoadNextScene(1));
        }
    }

    IEnumerator LoadNextScene(int scene)
    {
        loadingScreen.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
