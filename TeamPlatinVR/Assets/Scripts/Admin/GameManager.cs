using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera myCam;
    private GameObject player;
    private GameObject gazeObject;

    private static int gameState;

    //BedroomLevel
    private bool teddyCollected;
    private bool gearsCollected;
    private bool[] pickedUpBlocks = new bool[4];
    private bool[] placedBlocks = new bool[4];

    //DiscoLevel
    private bool[] spotlightArray = new bool[4];
    public bool destroyDiscoball;
    private bool keyCollected;

    //SnowLevel
    private bool[] newspaperArray = new bool[4];


    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        player.transform.position = GameObject.Find("StartingMovePoint").transform.position;

        playerPos = player.transform.position;
        playerPos = new Vector3(playerPos.x, playerPos.y - 1.5f, playerPos.z);
        
        gazeObject = null;
        newspaperArray[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gazeObject != null)
        {
            Debug.Log("Gaze Object Name: " + gameObject.name);
        }
    }

    public int GameState()
    {
        return gameState;
    }

    public void NextGameState()
    {
        gameState++;
    }

    public void FirstPuzzleWin(AudioClip winSound, Material newSkybox)
    {
        GameObject.Find("Portrait_Bild").GetComponent<Renderer>().enabled = true;
        GameObject.Find("Portrait_Bild").GetComponent<BoxCollider>().enabled = true;
        GameObject.Find("Portrait").GetComponent<AudioSource>().Play();
        
        AudioSource clockSounds = GameObject.Find("Grandfather-Clock").GetComponent<AudioSource>();
        clockSounds.loop = false;
        clockSounds.clip = winSound;
        clockSounds.Play();

        RenderSettings.skybox = newSkybox;
    }

    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y, location.z);
        playerPos = player.transform.position;
    }

    public void FloatAnimation(GameObject obj, float value, float floatSpeed, float rotSpeed)
    {
        Vector3 pos = obj.transform.position;
        float sinYPos = Mathf.Sin(Time.fixedTime * Mathf.PI * floatSpeed) * value;
        float YPos = obj.transform.position.y;
        float newY = sinYPos + YPos;
        obj.transform.position = new Vector3(pos.x, newY, pos.z);
        obj.transform.Rotate(Time.deltaTime * rotSpeed, 0, 0, Space.Self); 
    }

    public void PickUpTeddy()
    {
        teddyCollected = true;
    }

    public bool TeddyPickedUp()
    {
        return teddyCollected;
    }

    public void PickUpGears()
    {
        gearsCollected = true;
    }

    public void PickUpBlock(int blockNumber)
    {
        pickedUpBlocks[blockNumber] = true;
    }

    public void PlaceBlocks(int blockNumber)
    {
        placedBlocks[blockNumber] = true;
    }

    public bool IsBlockPickedUp(int blockNumber)
    {
        return pickedUpBlocks[blockNumber];
    }

    public bool CheckBlockPuzzle()
    {
        for(int i = 0; i < placedBlocks.Length; i++)
        {
            if(placedBlocks[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void SpotlightChecked(int spotlightIndex)
    {
        spotlightArray[spotlightIndex] = !spotlightArray[spotlightIndex];
    }

    public bool DiscoPuzzleWon()
    {
        for(int i = 0; i < spotlightArray.Length; i++)
        {
            if(spotlightArray[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void DestroyDiscoBall()
    {
        destroyDiscoball = true;
    }

    public void KeyCollected()
    {
        keyCollected = true;
    }

    public void PickUpNewsPaper(int index)
    {
        newspaperArray[index] = true;
    }

    public bool[] GetNewsPaperPieces()
    {
        return newspaperArray;
    }
}
