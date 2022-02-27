using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUpDown : GazeManager
{

    public GameObject book;
    private GameObject pageOne;
    private Transform pageOneTransform;
    private GameObject pageTwo;
    private Transform pageTwoTransform;
    private GameObject pageThree;
    private Transform pageThreeTransform;
    private GameObject pageFour;
    private Transform pageFourTransform;
    private int defaultRotation = 125;
    private bool directionPositive;
    private Transform page;
    private float timeUntil1;
    private float currentTimeDeltaTime;
    private bool rotationActive;

    private static int bookState;

    public override void Start()
    {

        base.Start();
        pageOne = book.transform.GetChild(0).gameObject;
        pageOneTransform = pageOne.GetComponent<Transform>();
        pageTwo = book.transform.GetChild(1).gameObject;
        pageTwoTransform = pageTwo.GetComponent<Transform>();
        pageThree = book.transform.GetChild(2).gameObject;
        pageThreeTransform = pageThree.GetComponent<Transform>();
        pageFour = book.transform.GetChild(3).gameObject;
        pageFourTransform = pageFour.GetComponent<Transform>();
        page = pageOneTransform;

        bookState = 1;

    }

    private void FixedUpdate()
    {
        if (rotationActive && timeUntil1 < 1)
        {
            doRotation();
        }
        else
        {
            rotationActive = false;
            timeUntil1 = 0;
        }
    }

    public override void ChangeOnGaze()
    {


        switch (this.name)
        {
            case "Cube":
                PageDown();
                break;
            case "Cube (1)":
                PageUp();
                break;
        }

        Debug.Log(bookState);
    }

    private void PageDown()
    {
        directionPositive = false;
        switch (bookState)
        {
            case 1:
                Debug.Log("Noooooo, I don't think sooo!");
                break;
            case 2:
                bookState--;
                rotationActive = true;
                page = pageTwoTransform;
                break;
            case 3:
                bookState--;
                rotationActive = true;
                page = pageThreeTransform;
                break;
        }
    }

    private void PageUp()
    {
        directionPositive = true;
        switch (bookState)
        {
            case 1:
                bookState++;
                rotationActive = true;
                page = pageTwoTransform;
                break;
            case 2:
                bookState++;
                rotationActive = true;
                page = pageThreeTransform;
                break;
            case 3:
                Debug.Log("Noooooo, I don't think sooo!");
                break;
        }
    }

    private void doRotation()
    {
        currentTimeDeltaTime = Time.deltaTime;
        timeUntil1 = timeUntil1 + currentTimeDeltaTime;
        if (directionPositive)
        {
           page.Rotate(new Vector3(defaultRotation * currentTimeDeltaTime, 0f, 0f), Space.Self);
        }
        else
        {
            page.Rotate(new Vector3((-defaultRotation) * currentTimeDeltaTime, 0f, 0f), Space.Self);
        }
    }
}
