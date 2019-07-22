using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour {
    private ParticleSystem waterPS;
    private int waterAmount;

    private void Start()
    {
        waterPS = GameObject.Find("Water Particles").GetComponent<ParticleSystem>();
        waterAmount = 500;
    }

    private void Update()
    {
        if (transform.eulerAngles.z > 60 && transform.eulerAngles.z < 180 && waterAmount != 0)
        {
            waterPS.Emit(1);
            waterAmount--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            if (waterAmount < 500)
            {
                waterAmount++;
                waterPS.Emit(1);
            }
        }
    }
}
