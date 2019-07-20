using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour {
    private ParticleSystem waterPS;

    private void Start()
    {
        waterPS = GameObject.Find("Water Particles").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (transform.eulerAngles.z > 60 && transform.eulerAngles.z < 180)
        {
            waterPS.Emit(1);
        }
    }
}
