using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePagesScript : MonoBehaviour
{
    private GameObject pageOne;
    private Transform pageOneTransform;
    private GameObject pageTwo;
    private Transform pageTwoTransform;
    private GameObject pageThree;
    private Transform pageThreeTransform;
    private GameObject pageFour;
    private Transform pageFourTransform;

    // Start is called before the first frame update
    void Start()
    {
        pageOne = transform.GetChild(0).gameObject;
        pageOneTransform = pageOne.GetComponent<Transform>();
        pageTwo = transform.GetChild(1).gameObject;
        pageTwoTransform = pageTwo.GetComponent<Transform>();
        pageThree = transform.GetChild(2).gameObject;
        pageThreeTransform = pageThree.GetComponent<Transform>();
        pageFour = transform.GetChild(3).gameObject;
        pageFourTransform = pageFour.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
