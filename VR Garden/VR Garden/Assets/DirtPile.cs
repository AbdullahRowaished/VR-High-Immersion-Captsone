using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour {
    private bool used = false;
    GameObject plant = null;
    private Produce produce;

    private void OnTriggerStay(Collider other)
    {
        if (!used)
        {
            if (other.CompareTag("Eggplant") | other.CompareTag("Corn") | other.CompareTag("Pumpkin") | other.CompareTag("Tomato"))
            {
                plant = other.gameObject;
                used = true;
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
