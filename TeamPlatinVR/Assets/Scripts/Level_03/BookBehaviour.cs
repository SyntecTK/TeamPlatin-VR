using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehaviour : GazeManager
{
    [SerializeField]
    private GameObject bigBook;

    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        bigBook.SetActive(true);
        GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
