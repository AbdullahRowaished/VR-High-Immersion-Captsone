using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private ComputeShader shader;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            shader.Dispatch(0, 0, 0, 0);
        }
    }
}
