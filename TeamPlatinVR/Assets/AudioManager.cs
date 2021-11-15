using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject uhr;
    public GameObject vögel;
    public GameObject gemälde;
    public GameObject radio;
    public GameObject ambience;

    public AudioClip uhrBell;
    public AudioClip uhrFast;

    private AudioSource uhrSound;
    private AudioSource vögelSound;
    private AudioSource gemäldeSound;
    private AudioSource radioSound;
    private AudioSource ambienceSound;

    
    // Start is called before the first frame update
    void Start()
    {
        uhrSound = uhr.GetComponent<AudioSource>();
        vögelSound = vögel.GetComponent<AudioSource>();
        gemäldeSound = gemälde.GetComponent<AudioSource>();
        radioSound = radio.GetComponent<AudioSource>();
        ambienceSound = ambience.GetComponent<AudioSource>();

        StartCoroutine(ChangeSounds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSounds()
    {
        yield return new WaitForSeconds(10);
        uhrSound.clip = uhrFast;
    	uhrSound.Play();
        Debug.Log("Play Fast");

        yield return new WaitForSeconds(uhrSound.clip.length);
        uhrSound.clip = uhrBell;
    	uhrSound.Play();
        Debug.Log("Play Bell");

        yield return new WaitForSeconds(3);
        vögelSound.Stop();

        yield return new WaitForSeconds(3);
        gemäldeSound.Play();

        //yield return new WaitForSeconds(5);
        //ambienceSound.Play();
    }
}
