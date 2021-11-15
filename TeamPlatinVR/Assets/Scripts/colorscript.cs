using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorscript : MonoBehaviour
{
    public Color onColor;
    public Color offColor;
    public Color waitColor;

    public Image gazeImage;

    private bool gaze;
    private float timer;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gaze==true)
        {
            if(duration > timer) {
                {
                    timer += Time.deltaTime;
                    gazeImage.fillAmount = timer / duration;
                }
            }else{
                timer = 0;
                ChangeOnGaze();
                gaze = false;
                gazeImage.fillAmount = 0;
            }
        }
    }

    public void ChangeOnGaze()
    {
        GetComponent<Renderer>().material.color = onColor;
    }

    public void ChangeOffGaze()
    {
        GetComponent<Renderer>().material.color = offColor;

        if(gaze)
        {
            gaze = false;
            gazeImage.fillAmount = 0;
        }
    }

    public void StartCount()
    {
        timer = 0;
        gaze = true;
        gameObject.GetComponent<Renderer>().material.color = waitColor;
    }
}
