using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJPultWinCheck : GazeManager
{
    
    [SerializeField]
    private Texture wrongTex;
    [SerializeField]
    private Texture rightTex;

    private Material showMat;

    public override void Start()
    {
        base.Start();
        showMat = GetComponent<Renderer>().materials[1];
    }

    public override void ChangeOnGaze()
    {
        if(gM.DiscoPuzzleWon())
        {
            SetTexture(rightTex, Color.green);
            StartCoroutine(EmissionCycle(showMat));
            gM.DestroyDiscoBall();
        }else{
            SetTexture(wrongTex, Color.red);
            StartCoroutine(EmissionCycle(showMat));
        }
    }

    private void SetTexture(Texture tex, Color c)
    {
        showMat.SetTexture("_EmissionMap", tex);
        showMat.SetColor("_EmissionColor", c);
    }

    IEnumerator EmissionCycle(Material mat)
    {
        mat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(3);
        mat.DisableKeyword("_EMISSION");
    }
}
