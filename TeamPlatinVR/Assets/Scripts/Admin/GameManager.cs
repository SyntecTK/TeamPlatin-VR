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
        //playerPos = player.transform.position;
        //playerPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        //player.transform.position = playerPos;
        
        gazeObject = null;
        newspaperArray[0] = true;
        Debug.Log(gameState);
    }

    // Update is called once per frame
    void Update()
    {
        if(gazeObject != null)
        {
            Debug.Log("Gaze Object Name: " + gameObject.name);
        }
    }

    //Getter und Setter für die GameState
    //Nach dem GameState richten sich viele Objekte im Office-Level
    //Da dieses als eine Art Hub dient und nach jedem Level neu besucht wird
    public int GameState()
    {
        return gameState;
    }

    public void NextGameState()
    {
        gameState++;
    }

    //Was passieren soll, nachdem das Puzzle im ersten Raum gelöst wird
    //Es ertönt Musik, das Gemälde zeigt das Bild vom nächsten Level und ist betretbar
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

    //Diese Methode nutzen die Movepoints um den Player zu bewegen
    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y, location.z);
        playerPos = player.transform.position;
    }

    //Wird benutzt um Objekte leicht nach oben und unten zu bewegen
    //die Position auf der Y-Achse bewegt sich dabei quasi auf einer Sinuskurve hoch und runter
    public void FloatAnimation(GameObject obj, float value, float floatSpeed, float rotSpeed)
    {
        Vector3 pos = obj.transform.position;
        float sinYPos = Mathf.Sin(Time.fixedTime * Mathf.PI * floatSpeed) * value;
        float YPos = obj.transform.position.y;
        float newY = sinYPos + YPos;
        obj.transform.position = new Vector3(pos.x, newY, pos.z);
        obj.transform.Rotate(Time.deltaTime * rotSpeed, 0, 0, Space.Self); 
    }

    //Getter und Setter dafür, ob man den Teddy im Zweiten Level aufgehoben hat
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

    //Setzt einen bool in einem bool Array, welcher die Aufgehobenen Blöcke verfolgt,
    // auf True dabei ist der Index, der des Aufgehobenen Blocks
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

    //Überprüft, ob alle Blöcke aufgesammelt wurden
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
