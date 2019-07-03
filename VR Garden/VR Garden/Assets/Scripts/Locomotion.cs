using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Locomotion : MonoBehaviour {
    private GameObject player;
    private bool locomotive;
    private Vector2 axis;
    private float xLS, yLS, speed;

    private void Start()
    {
        player = GameObject.Find("Player");
        locomotive = false;
        speed = 0.1f;
    }

    private void Update()
    {
        GetLeftStickValues();
        if(locomotive)
        {
            MovePlayer();
        }
    }

    private void GetLeftStickValues()
    {
        //axis = SteamVR_Actions.default_Locomotion.GetAxis(SteamVR_Input_Sources.LeftHand);
        //xLS = axis.x;
       // yLS = axis.y;
        //locomotive = xLS > 0.2f | xLS < -0.2f | yLS > 0.2f | yLS < -0.2f;
    }

    private void MovePlayer()
    {
        //player.transform.Translate(speed*xLS, 0, speed*yLS);
    }
}
