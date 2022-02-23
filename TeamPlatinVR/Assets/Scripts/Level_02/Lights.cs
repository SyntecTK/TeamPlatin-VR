using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : GazeManager
{
    public int winNumber;

    private Light light;
    private Material glassMat;

    private Color winColor;
    
    private Color color1;
    private Color color2;
    private Color color3;
    private Color color4;
    private Color color5;

    private int counter;

    private List<Color> colorList = new List<Color>();

    private bool lightActive;
    private bool lightCorrect;
    
    public override void Start()
    {
        base.Start();
        glassMat = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        light = transform.GetChild(1).gameObject.GetComponent<Light>();

        winColor = glassMat.GetColor("_EmissionColor");
        
        color1 = new Color(0, 155, 204);    //Türkis
        color2 = new Color(4, 191, 0);     //Grün
        color3 = new Color(199, 0, 204);    //Pink
        color4 = new Color(196, 204, 0);    //Yellow

        colorList.Add(color1);
        colorList.Add(color2);
        colorList.Add(color3);
        colorList.Add(color4);

        lightActive = true;

        StartCoroutine(LightRotation());

    }

    public override void ChangeOnGaze()
    {
        if(lightActive)
        {
            lightActive = false;
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            if(counter == winNumber)
            {
                gM.SpotlightChecked(winNumber);
                lightCorrect = true;
            }
        }else
        {
            lightActive = true;
            GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            if(lightCorrect)
            {
                gM.SpotlightChecked(winNumber);
                lightCorrect = false;
            }
        }
            
    }

    private void SwitchLightColor(Color color)
    {
        light.color = color;
        glassMat.SetColor("_EmissionColor", color / 56f);
    }

    IEnumerator LightRotation()
    {
        Color c;
        while(true)
        {
            yield return new WaitForSeconds(6);
            c = colorList[counter];
            if(lightActive)
            {
                SwitchLightColor(c);
            }
            counter++;
            counter = counter%4;
        }
    }
}
