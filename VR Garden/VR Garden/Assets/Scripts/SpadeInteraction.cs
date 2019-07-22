using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeInteraction : MonoBehaviour {
    private GameLogic gl;
    private GameObject tip;
    private int shovelcount; //must shovel several times until a dirtpile shows up

    private void Start()
    {
        gl = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        tip = GameObject.Find("SpadeTip");
        shovelcount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            if (shovelcount == 10)
            {
                gl.AddDirt(tip.transform.position);
                shovelcount = 0;
            }
            else
            {
                GetComponentInChildren<ParticleSystem>().Play();
                shovelcount++;
            }
        }
    }
}
