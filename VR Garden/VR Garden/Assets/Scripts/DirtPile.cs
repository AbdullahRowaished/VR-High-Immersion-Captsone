using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour {
    public bool used = false;
    public GameObject seed = null;
    public Produce produce;
    public int waterAmount, maxWater;


    private List<ParticleCollisionEvent> pcEvents;

    private void Start()
    {
        pcEvents = new List<ParticleCollisionEvent>();
        waterAmount = 0;
        maxWater = 1000;
    }

    private void Update()
    {
        if (waterAmount >= maxWater)
        {
            Debug.Log("plant has been watered");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!used)
        {
            if (other.gameObject.CompareTag("Eggplant") | other.gameObject.CompareTag("Corn") | other.gameObject.CompareTag("Pumpkin") | other.gameObject.CompareTag("Tomato"))
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.SetParent(transform);
                seed = other.gameObject;
                used = true;
            } else
            {
                return;
            }

            if (other.gameObject.CompareTag("Eggplant"))
            {
                produce = Produce.EGGPLANT;
                maxWater = 250;
            } else if (other.gameObject.CompareTag("Corn"))
            {
                produce = Produce.CORN;
                maxWater = 350;
            } else if (other.gameObject.CompareTag("Pumpkin"))
            {
                produce = Produce.PUMPKIN;
                maxWater = 500;
            } else if (other.gameObject.CompareTag("Tomato"))
            {
                produce = Produce.TOMATO;
                maxWater = 100;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterCan"))
        {
            int numCollisionEvents = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, pcEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                waterAmount++;
                i++;
            }
        }
    }
}
