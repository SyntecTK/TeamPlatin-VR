using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeManager : MonoBehaviour
{
    //Von dem GazeManager soll jedes Script erben, welches auf einem Objekt mit GazeInteraktion liegt
    //Dieser ist nach dem Tutorial aus diesem Kurs aufgebaut,
    //nur dass er noch den GameManager initialisiert
    
    public Image gazeImage;
    public float duration;

    private bool gaze;
    private float timer;

    protected GameManager gM;

    public virtual void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(gaze==true)
        {
            if(duration > timer)
            {
                    timer += Time.deltaTime;
                    gazeImage.fillAmount = timer / duration;
            }else{
                timer = 0;
                ChangeOnGaze();
                gaze = false;
                gazeImage.fillAmount = 0;
            }
        }
    }
    public void StartCount()
    {
        timer = 0;
        gaze = true;
    }

    public virtual void ChangeOnGaze(){}

    public void ChangeOffGaze()
    {
        if(gaze)
        {
            gaze = false;
            gazeImage.fillAmount = 0;
        }
    }
}
