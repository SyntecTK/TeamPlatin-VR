using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawers : GazeManager
{
    bool drawerBluePushed;
    bool drawerWhitePushed;
    bool drawerGreenPushed;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void ChangeOnGaze()
    {
        Vector3 startPos = transform.position;
        switch(this.name)
        {
            case "DrawerBlue":
                if(!drawerBluePushed)
                {
                    MoveDrawer(startPos, new Vector3(0, 0, -1), 0.5f);
                    GetComponent<AudioSource>().Play();
                    drawerBluePushed = true;
                }else{
                    MoveDrawer(startPos, new Vector3(0, 0, 1), 0.5f);
                    drawerBluePushed = false;
                }
                break;
            case "DrawerGreen":
                if(!drawerGreenPushed)
                {
                    MoveDrawer(startPos, new Vector3(0, 0, 1), 0.4f);
                    GetComponent<AudioSource>().Play();
                    drawerGreenPushed = true;
                }else{
                    MoveDrawer(startPos, new Vector3(0, 0, -1), 0.4f);
                    drawerGreenPushed = false;
                }
                break;
            case "DrawerWhite":
                if(!drawerWhitePushed && gM.TeddyPickedUp())
                {
                    GameObject ted = GameObject.Find("BlockTeddy02");
                    ted.GetComponent<MeshRenderer>().enabled = true;
                    MoveDrawer(startPos, new Vector3(-1, 0, 0), 0.4f);
                    GetComponent<AudioSource>().Play();
                    drawerWhitePushed = true;
                }else if (drawerWhitePushed){
                    MoveDrawer(startPos, new Vector3(1, 0, 0), 0.4f);
                    drawerWhitePushed = false;
                }
                break;
        }
    }

    private void MoveDrawer(Vector3 startPos, Vector3 offSet, float distance)
    {
        Vector3 endPos = new Vector3(startPos.x + offSet.x, startPos.y + offSet.y, startPos.z + offSet.z);
        transform.position = Vector3.MoveTowards(startPos, endPos, distance);
    }
}
