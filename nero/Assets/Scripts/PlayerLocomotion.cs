using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7;
    public float rotationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform; //scan scene for default camera tag
    }

    public void HandleAllMovement()
    {
        HandleAllMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput; //set camera to track player movement on vertical axis
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //track horizontal movement
        moveDirection.Normalize(); //maintain direction vector + set length to 1
        moveDirection.y = 0; //lock player's vertical movement; ground player
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity; //move player according to calculations
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero; //default value = 0

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //quaternion = unity rotation calculations
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //slerp = rotation between point A + B

        transform.rotation = playerRotation;
    }
}
