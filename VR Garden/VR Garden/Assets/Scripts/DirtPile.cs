using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour {
    public bool used = false;
    public GameObject seed = null;
    public Produce produce;
    public int waterAmount;


    private List<ParticleCollisionEvent> pcEvents;

    private void Start()
    {
        pcEvents = new List<ParticleCollisionEvent>();
        waterAmount = 0;
    }

    private void Update()
    {
        if (waterAmount >= 10000)
        {
            Debug.Log("plant has been watered");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (other.CompareTag("Eggplant") | other.CompareTag("Corn") | other.CompareTag("Pumpkin") | other.CompareTag("Tomato"))
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.SetParent(transform);
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

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterCan"))
        {
            int numCollisionEvents = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, pcEvents);
            int i = 0;

            while (i < numCollisionEvents)
            {
                waterAmount++;
                Debug.Log("WaterAmount: " + waterAmount);
                i++;
            }
        }
    }
}
