﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Locomotion : MonoBehaviour
{
    private GameObject player;
    private CharacterController charControl;
    private Transform vrcTransform;
    private bool locomotive, eyeing;
    private Vector2 Laxis, Raxis;
    private float xLS, yLS, xRS, speed, t;

    private void Start()
    {
        player = GameObject.Find("Player");
        vrcTransform = GameObject.Find("VRCamera").transform;
        charControl = player.GetComponent<CharacterController>();
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

        if(!charControl.isGrounded)
        {
            charControl.Move(Vector3.down * 9.8f);
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

        Vector3 euler = new Vector3(0, vrcTransform.eulerAngles.y, 0);
        Quaternion quat = Quaternion.Euler(euler);

        charControl.Move(quat * (new Vector3(xLS, 0, yLS) * t * speed));
    }

    private void RotateCamera()
    {
        t = Time.deltaTime;
        speed = 100;
        player.transform.Rotate(0, xRS * t * speed, 0);
    }
}
