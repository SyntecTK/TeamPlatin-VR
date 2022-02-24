using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJPultWinCheck : GazeManager
{
    
    [SerializeField]
    private Texture wrongTex;
    [SerializeField]
    private Texture rightTex;
    [SerializeField]
    private AudioClip loseSound;

    private AudioClip winSound;
    private AudioSource soundSource;

    private Material showMat;

    public override void Start()
    {
        base.Start();
        showMat = GetComponent<Renderer>().materials[1];
        soundSource = GetComponent<AudioSource>();
        winSound = GetComponent<AudioSource>().clip;
    }

    public override void ChangeOnGaze()
    {
        if(gM.DiscoPuzzleWon())
        {
            SetTexture(rightTex, Color.green);
            StartCoroutine(EmissionCycle(showMat));
            PlayCorrectSound();
            gM.DestroyDiscoBall();
        }else{
            SetTexture(wrongTex, Color.red);
            StartCoroutine(EmissionCycle(showMat));
            PlayCorrectSound();
        }
    }

    private void SetTexture(Texture tex, Color c)
    {
        showMat.SetTexture("_EmissionMap", tex);
        showMat.SetColor("_EmissionColor", c);
    }

    private void PlayCorrectSound()
    {
        if(gM.DiscoPuzzleWon())
        {
            soundSource.clip = winSound;
            soundSource.Play();
        }else{
            soundSource.clip = loseSound;
            soundSource.Play();
        }
    }

    IEnumerator EmissionCycle(Material mat)
    {
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(3);
        mat.DisableKeyword("_EMISSION");
    }
}
