using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour {
    public bool used = false;
    public GameObject seed = null;
    public Produce produce;

    private void OnTriggerStay(Collider other)
    {
        if (!used)
        {
            if (other.CompareTag("Eggplant") | other.CompareTag("Corn") | other.CompareTag("Pumpkin") | other.CompareTag("Tomato"))
            {
                seed = other.gameObject;
                used = true;
            } else
            {
                return;
            }

            if (other.CompareTag("Eggplant"))
            {
                produce = Produce.EGGPLANT;
            } else if (other.CompareTag("Corn"))
            {
                produce = Produce.CORN;
            } else if (other.CompareTag("Pumpkin"))
            {
                produce = Produce.PUMPKIN;
            } else if (other.CompareTag("Tomato"))
            {
                produce = Produce.TOMATO;
            }
        }
    }
}
