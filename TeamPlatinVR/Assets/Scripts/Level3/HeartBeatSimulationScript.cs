using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatSimulationScript : MonoBehaviour
{
    private Renderer renderer;
    private Texture staticTexture;
    public Texture peakTexture;
    private Texture[] textures;
    private int textureNumber;
    private float counter;
    private bool textureOne;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        staticTexture = renderer.materials[1].GetTexture("_EmissionMap");
        textures = new Texture[2];
        textures[0] = staticTexture;
        textures[1] = peakTexture;
        textureNumber = 0;
        counter = 0;
    }

    void FixedUpdate(){
        counter += Time.deltaTime;
        if(!textureOne && counter >= 0.7){
            textureNumber = 1;
            ChangeTexture();
            textureOne = true;
        } else if (textureOne && counter>1){
            textureNumber = 0;
            ChangeTexture();
            counter = 0;
            textureOne = false;
        }
    }

    private void ChangeTexture(){
        renderer.materials[1].SetTexture("_EmissionMap", textures[textureNumber]);
    }
}
