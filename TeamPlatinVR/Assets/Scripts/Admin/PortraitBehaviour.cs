using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitBehaviour : GazeManager
{
    private int sceneIndex;
    
    public override void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChangeOnGaze()
    {
        if(sceneIndex == 0)
        {
            
        }else if(sceneIndex == 1)
        {
            
        }else if(sceneIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
    }
}
