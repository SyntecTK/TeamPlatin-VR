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
        playerPos.y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos.y > 0f)
            playerPos.y = -1;
    }

    public void MovePlayer(Vector3 location)
    {
        player.transform.position = new Vector3(location.x, location.y, location.z);
        playerPos = player.transform.position;
    }
}
