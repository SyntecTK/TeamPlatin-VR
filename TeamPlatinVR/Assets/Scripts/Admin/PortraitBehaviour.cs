using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitBehaviour : GazeManager
{
    private int sceneIndex;
    public GameObject loadingScreen;


    [SerializeField]
    private Texture level1Tex;
    [SerializeField]
    private Texture level2Tex;
    [SerializeField]
    private Texture endTex;

    public override void Start()
    {
        base.Start();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 1)
        {
            switch (gM.GameState())
            {
                case 0:
                    GetComponent<Renderer>().material.mainTexture = level1Tex;
                    break;
                case 1:
                    GetComponent<Renderer>().material.mainTexture = level2Tex;
                    break;
            }
        }else if(sceneIndex == 4)
        {
            GetComponent<Renderer>().material.mainTexture = endTex;
        }
    }

    public override void ChangeOnGaze()
    {
        if (sceneIndex == 1)
        {
            switch (gM.GameState())
            {
                case 0:
                    StartCoroutine(LoadNextScene(2));
                    break;
                case 1:
                    StartCoroutine(LoadNextScene(3));
                    break;
            }

        }
        else if (sceneIndex == 4)
        {
            StartCoroutine(LoadNextScene(5));
        }
        else
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
