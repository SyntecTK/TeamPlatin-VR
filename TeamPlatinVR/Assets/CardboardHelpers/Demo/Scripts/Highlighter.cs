using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Color hoverColor;
    public Color selectColor;

    private Color defaultColor;
    private Renderer rnd;

    private void Start()
    {
        rnd = GetComponent<Renderer>();
        defaultColor = rnd.material.color;
    }

    public void Hovering(bool enable)
    {
        rnd.material.color = (enable ? hoverColor : defaultColor);
    }

    public void Selecting(bool enable)
    {
        rnd.material.color = (enable ? selectColor : defaultColor);
    }

}
