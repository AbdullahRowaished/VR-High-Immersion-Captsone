using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private ComputeShader shader;
    public Texture texture;
    private int kernel;

    private void Start()
    {
        kernel = shader.FindKernel("CSMain");
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Ball has hit the Cube");
            shader.SetTexture(kernel, "Texture", texture);
            shader.Dispatch(kernel, 2, 3 , 1);
        }
    }
}
