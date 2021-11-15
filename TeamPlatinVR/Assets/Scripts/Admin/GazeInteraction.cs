using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInteraction : MonoBehaviour
{
    public Image gazeImage;
    public Color usedButton;

    private Color baseColor;
    private GameManager gameManager;
    private Rigidbody rigidbody;
    private GameObject pointer;
    private Vector3 pointerStartPos;
    private AudioSource radio;

    private float pushStrength;
    private bool gaze;
    private float timer;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<Renderer>().material.color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidbody = GetComponent<Rigidbody>();
        radio = GetComponentInParent<AudioSource>();
        pushStrength = 100f;
        pointer = GameObject.Find("Pointer");
        pointerStartPos = pointer.transform.position;
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
        switch(this.tag)
        {
            case "Teddy":
                rigidbody.AddForce(transform.forward * pushStrength * -1);
                break;
            case "MovePoint":
                gameManager.MovePlayer(this.transform.position);
                break;
            case "Button": 
                StartCoroutine(ChangeButtonColor());
                switch (this.name)
                {
                    case "Button":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0);
                        break;
                    case "Button 2":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.03f);
                        break;
                    case "Button 3":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.06f);
                        break;
                    case "Button 4":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.09f);
                        radio.Play();
                        break;
                    case "Button 5":
                        pointer.transform.position = pointerStartPos + new Vector3(0, 0, 0.12f);
                        break;
                }
                break;
        }
        

    }

    public void ChangeOffGaze()
    {
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
    }

    IEnumerator ChangeButtonColor()
    {
        GetComponent<Renderer>().material.color = usedButton;
        yield return new WaitForSeconds(3);
        GetComponent<Renderer>().material.color = baseColor;
    }
}
