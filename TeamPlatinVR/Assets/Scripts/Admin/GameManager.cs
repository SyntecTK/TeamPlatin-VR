using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        playerPos = player.transform.position;
        //player.transform.position = new Vector3(playerPos.x, playerPos.y - 1, playerPos.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y - 1, location.z);
        playerPos = player.transform.position;
    }
}
