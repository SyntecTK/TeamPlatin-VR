using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BottleScript : GazeManager
{
    public Volume gameVolume;
    private Bloom bloom;
    private LensDistortion lensDistortion;
    private ChromaticAberration chromaticAberration;
    private bool drunk = false;


    public override void Start()
    {
        base.Start();
        gameVolume.profile.TryGet(out bloom);
        gameVolume.profile.TryGet(out lensDistortion);
        gameVolume.profile.TryGet(out chromaticAberration);
    }

    public override void ChangeOnGaze()
    {
        if (!drunk)
        {
            StartCoroutine(SimulateDrinking());
        }
    }

    IEnumerator SimulateDrinking()
    {
        drunk = true;
        yield return new WaitForSeconds(1);
        lensDistortion.active = true;
        chromaticAberration.active = true;

        for (int i = 0; i < 2; i++)
        {
            bloom.intensity.value += 1.5f;
            lensDistortion.intensity.value -= 0.4f;
            chromaticAberration.intensity.value += 0.37f;
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(9);

        for (int i = 0; i < 4; i++)
        {
            bloom.intensity.value -= 0.75f;
            lensDistortion.intensity.value += 0.2f;
            chromaticAberration.intensity.value -= 0.185f;
            yield return new WaitForSeconds(1);
        }

        lensDistortion.active = false;
        chromaticAberration.active = false;
        drunk = false;
    }
}
