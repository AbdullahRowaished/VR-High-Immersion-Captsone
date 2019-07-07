using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Locomotion : MonoBehaviour
{
    private GameObject player;
    private Transform vrcTransform;
    private bool locomotive, eyeing;
    private Vector2 Laxis, Raxis;
    private float xLS, yLS, xRS, speed, t;

    private void Start()
    {
        player = GameObject.Find("Player");
        vrcTransform = GameObject.Find("VRCamera").transform;
        locomotive = false;
        eyeing = false;
    }

    private void Update()
    {
        GetLeftStickValues();
        GetRightStickValues();
        if (locomotive)
        {
            MovePlayer();
        }
        if (eyeing)
        {
            RotateCamera();
        }
    }

    private void GetLeftStickValues()
    {
        Laxis = SteamVR_Actions.default_Locomotion.GetAxis(SteamVR_Input_Sources.LeftHand);
        xLS = Laxis.x;
        yLS = Laxis.y;
        locomotive = xLS > 0.2f | xLS < -0.2f | yLS > 0.2f | yLS < -0.2f;
    }
    private void GetRightStickValues()
    {
        Raxis = SteamVR_Actions.default_Camera.GetAxis(SteamVR_Input_Sources.RightHand);
        xRS = Raxis.x;
        eyeing = xRS > 0.2f | xRS < -0.2f;
    }

    private void MovePlayer()
    {
        t = Time.deltaTime;
        speed = 10;
        player.transform.Translate(t*speed*xLS, 0, t*speed*yLS);
    }

    private void RotateCamera()
    {
        t = Time.deltaTime;
        speed = 100;
        player.transform.Rotate(0, xRS * t * speed, 0);
    }
}
