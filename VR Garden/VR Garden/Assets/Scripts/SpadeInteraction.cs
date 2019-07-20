using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeInteraction : MonoBehaviour {
    public GamePools gp;
    private GameObject tip;

    private void Start()
    {
        tip = GameObject.Find("SpadeTip");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            gp.PoolObject(tip.transform.position, "Dirt");
        }
    }
}
