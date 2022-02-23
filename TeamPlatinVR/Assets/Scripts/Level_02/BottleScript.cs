using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BottleScript : GazeManager
{
    public Volume gameVolume;
    private Bloom bloom;


    public override void Start()
    {
        base.Start();
        gameVolume.profile.TryGet(out bloom);
    }

    public override void ChangeOnGaze()
    {
        bloom.intensity.value = 2;
    }
}
