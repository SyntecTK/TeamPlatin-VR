using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : GazeManager
{
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    public override void ChangeOnGaze()
    {
        SceneManager.LoadScene(1);
    }
}
