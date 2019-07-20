using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeInteraction : MonoBehaviour {
    public GamePools gp;
    private GameObject tip;
    private int shovelcount; //must shovel several times until a dirtpile shows up

    private void Start()
    {
        tip = GameObject.Find("SpadeTip");
        shovelcount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            if (shovelcount == 10)
            {
                gp.PoolObject(tip.transform.position, "Dirt");
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
