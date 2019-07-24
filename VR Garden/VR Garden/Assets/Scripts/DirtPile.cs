using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour {
    public bool planted, sprouted;
    public GameObject seed = null;
    public Produce produce;
    public int waterAmount, maxWater;
    private GameLogic gameLogic;


    private List<ParticleCollisionEvent> pcEvents;

    private void Start()
    {
        pcEvents = new List<ParticleCollisionEvent>();
        waterAmount = 0;
        maxWater = 1000;
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        sprouted = false;
        planted = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!planted)
        {
            if (other.gameObject.CompareTag("Eggplant") | other.gameObject.CompareTag("Corn") | other.gameObject.CompareTag("Pumpkin") | other.gameObject.CompareTag("Tomato"))
            {
                seed = other.gameObject;
                seed.GetComponent<Rigidbody>().isKinematic = true;
                seed.transform.SetParent(transform);
                seed.SetActive(false);
                planted = true;
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
        if (other.CompareTag("WaterCan") && !sprouted)
        {
            int numCollisionEvents = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, pcEvents);
            int i = 0;

            while (i < numCollisionEvents && waterAmount < maxWater)
            {
                waterAmount++;
                i++;
            }

            if (waterAmount == maxWater && planted)
            {
                gameLogic.GrowCrops(transform.position, seed.tag);
                sprouted = true;
            }
        }
    }
}
