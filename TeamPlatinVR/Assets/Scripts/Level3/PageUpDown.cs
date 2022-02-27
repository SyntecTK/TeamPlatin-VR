using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUpDown : GazeManager
{

    public GameObject book;
    public GameObject UIElements;
    private GameObject pageOne;
    private Transform pageOneTransform;
    private GameObject pageTwo;
    private Transform pageTwoTransform;
    private GameObject pageThree;
    private Transform pageThreeTransform;
    private GameObject pageFour;
    private Transform pageFourTransform;
    private int defaultRotation;
    private bool directionPositive;
    private Transform page;
    private float timeUntil1;
    private float currentTimeDeltaTime;
    private bool rotationActive;

    //Snippets
    private GameObject choiceSnippet1;
    private GameObject choiceSnippet2;
    private GameObject choiceSnippet3;

    private GameObject originalSnippet1;
    private GameObject originalSnippet2;
    private GameObject originalSnippet3;

    private Color snippet1Color;
    private Color snippet2Color;
    private Color snippet3Color;

    //Texts
    private List<GameObject> originalTextList;

    private bool visibilityBool;

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

        //Snippets
        choiceSnippet1 = GameObject.Find("Choice1Snippet");
        choiceSnippet2 = GameObject.Find("Choice2Snippet");
        choiceSnippet3 = GameObject.Find("Choice3Snippet");

        originalSnippet1 = GameObject.Find("Snippet1");
        originalSnippet2 = GameObject.Find("Snippet2");
        originalSnippet3 = GameObject.Find("Snippet3");

        snippet1Color = originalSnippet1.GetComponent<Renderer>().material.color;
        snippet2Color = originalSnippet2.GetComponent<Renderer>().material.color;
        snippet3Color = originalSnippet3.GetComponent<Renderer>().material.color;

        //Texts
        originalTextList = new List<GameObject>();
        originalTextList.Add(GameObject.Find("SnippetPage1Option1"));
        originalTextList.Add(GameObject.Find("SnippetPage1Option2"));
        originalTextList.Add(GameObject.Find("SnippetPage1Option3"));
        originalTextList.Add(GameObject.Find("SnippetPage2Option1"));
        originalTextList.Add(GameObject.Find("SnippetPage2Option2"));
        originalTextList.Add(GameObject.Find("SnippetPage2Option3"));
        originalTextList.Add(GameObject.Find("SnippetPage3Option1"));
        originalTextList.Add(GameObject.Find("SnippetPage3Option2"));
        originalTextList.Add(GameObject.Find("SnippetPage3Option3"));

        bookState = 1;
        defaultRotation = 165;

    }

    private void FixedUpdate()
    {
        if (rotationActive && timeUntil1 < 1)
        {
            DoRotation();
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
            case "arrowLeft":
                PageDown();
                break;
            case "arrowRight":
                PageUp();
                break;
            case "Choice1Snippet":
                SnippetAction(0);
                break;
            case "Choice2Snippet":
                SnippetAction(1);
                break;
            case "Choice3Snippet":
                SnippetAction(2);
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
                ChangeSnippetColor(snippet1Color);
                bookState--;
                SwitchSnippetAnswers();
                rotationActive = true;
                page = pageTwoTransform;
                break;
            case 3:
                ChangeSnippetColor(snippet2Color);
                bookState--;
                SwitchSnippetAnswers();
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
                ChangeSnippetColor(snippet2Color);
                bookState++;
                SwitchSnippetAnswers();
                rotationActive = true;
                page = pageTwoTransform;
                break;
            case 2:
                ChangeSnippetColor(snippet3Color);
                bookState++;
                SwitchSnippetAnswers();
                rotationActive = true;
                page = pageThreeTransform;
                break;
            case 3:
                Debug.Log("Noooooo, I don't think sooo!");
                break;
        }
    }

    private void DoRotation()
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

    private void SnippetAction(int id)
    {
        //turns snippet on corresponding page visible
        switch (bookState)
        {
            case 1:
                originalSnippet1.GetComponent<MeshRenderer>().enabled = true;
                break;
            case 2:
                originalSnippet2.GetComponent<MeshRenderer>().enabled = true;
                break;
            case 3:
                originalSnippet3.GetComponent<MeshRenderer>().enabled = true;
                break;
        }
        makeTextVisible(id);
        CheckWinCon();
    }

    private void ChangeSnippetColor(Color c)
    {
        choiceSnippet1.GetComponent<Renderer>().material.color = c;
        choiceSnippet2.GetComponent<Renderer>().material.color = c;
        choiceSnippet3.GetComponent<Renderer>().material.color = c;
    }

    private void SwitchSnippetAnswers()
    {
        for(int i = 0; i<3; i++) {
            if (i == bookState-1) {
                visibilityBool = true;
            }
            else
            {
                visibilityBool = false;
            }
            choiceSnippet1.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = visibilityBool;
            choiceSnippet2.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = visibilityBool;
            choiceSnippet3.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = visibilityBool;
        }
    }

    private void makeTextVisible(int id)
    {
        originalTextList[id + 3 * (bookState - 1)].GetComponent<Renderer>().enabled = true;
        switch (id)
        {
            case 0:
                originalTextList[(id + 3 * (bookState - 1)) + 1].GetComponent<Renderer>().enabled = false;
                originalTextList[(id + 3 * (bookState - 1)) + 2].GetComponent<Renderer>().enabled = false;
                break;
            case 1:
                originalTextList[(id + 3 * (bookState - 1)) + 1].GetComponent<Renderer>().enabled = false;
                originalTextList[(id + 3 * (bookState - 1)) - 1].GetComponent<Renderer>().enabled = false;
                break;
            case 2:
                originalTextList[(id + 3 * (bookState - 1) - 1)].GetComponent<Renderer>().enabled = false;
                originalTextList[(id + 3 * (bookState - 1)) - 2].GetComponent<Renderer>().enabled = false;
                break;
        }
    }
    
    private void CheckWinCon()
    {
        if(originalTextList[0].GetComponent<Renderer>().enabled == true &&
            originalTextList[3].GetComponent<Renderer>().enabled == true &&
            originalTextList[8].GetComponent<Renderer>().enabled == true)
        {
            //enter what happens when won
            Debug.Log("You won!");
        }
    }
}
