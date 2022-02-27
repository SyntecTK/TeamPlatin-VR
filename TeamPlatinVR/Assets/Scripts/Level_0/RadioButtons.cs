using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioButtons : GazeManager
{
    private GameObject pointer;
    private AudioSource radio;

    private Vector3 pointerStartPos;

    [SerializeField]
    private Color usedButton;
    private Color baseColor;

    [SerializeField]
    private AudioClip radio01;
    [SerializeField]
    private AudioClip radio02;
    [SerializeField]
    private AudioClip radio03;
    [SerializeField]
    private AudioClip radio04;
    [SerializeField]
    private AudioClip radio05;

    public override void Start()
    {
        base.Start();
        pointer = GameObject.Find("Pointer");
        pointerStartPos = pointer.transform.position;

        radio = GameObject.Find("Radio").GetComponent<AudioSource>();
        baseColor = GetComponent<Renderer>().material.color;
    }

    public override void ChangeOnGaze()
    {
        StartCoroutine(ChangeButtonColor());
        switch (this.name)
        {
            case "Button":
                pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0);
                radio.Stop();
                radio.clip = radio01;
                radio.Play();
                break;
            case "Button 2":
                pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.03f);
                radio.Stop();
                radio.clip = radio02;
                radio.Play();
                break;
            case "Button 3":
                pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.06f);
                radio.Stop();
                radio.clip = radio03;
                radio.Play();
                break;
            case "Button 4":
                pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.09f);
                radio.Stop();
                radio.clip = radio04;
                radio.Play();
                break;
            case "Button 5":
                pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.12f);
                radio.Stop();
                radio.clip = radio05;
                radio.Play();
                break;
        }
    }

    IEnumerator ChangeButtonColor()
    {
        GetComponent<Renderer>().material.color = usedButton;
        yield return new WaitForSeconds(3);
        GetComponent<Renderer>().material.color = baseColor;
    }
}
