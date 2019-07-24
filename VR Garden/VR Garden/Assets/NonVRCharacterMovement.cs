using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRCharacterMovement : MonoBehaviour {
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            characterController.Move(transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            characterController.Move(-transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            characterController.Move(transform.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            characterController.Move(-transform.right);
        }
    }
}
