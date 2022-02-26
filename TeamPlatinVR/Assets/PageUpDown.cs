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

        bookState = 1;

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
        switch (bookState)
        {
            case 1:
                Debug.Log("Noooooo, I don't think sooo!");
                break;
            case 2:
                pageTwoTransform.Rotate(-129, 0, 0);
                bookState--;
                break;
            case 3:
                pageThreeTransform.Rotate(-129, 0, 0);
                bookState--;
                break;
        }
    }

    private void PageUp()
    {
        switch (bookState)
        {
            case 1:
                pageTwoTransform.Rotate(129, 0, 0);
                bookState++;
                break;
            case 2:
                pageThreeTransform.Rotate(129, 0, 0);
                bookState++;
                break;
            case 3:
                Debug.Log("Noooooo, I don't think sooo!");
                break;
        }
    }
}
