using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRCharacterMovement : MonoBehaviour {
    CharacterController characterController;
    Vector3 currentMousePosition, previousMousPosition;
    Transform cameraTransform;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Transform>();
        previousMousPosition = Vector3.zero;
        previousMousPosition.y = Input.mousePosition.x;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move((-transform.forward));
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-transform.right);
        }
        currentMousePosition = Vector3.zero;
        currentMousePosition.y = Input.mousePosition.x;
        Vector3 displacement = currentMousePosition - previousMousPosition;
        
        transform.Rotate(displacement);
        
        previousMousPosition = currentMousePosition;
    }
}
