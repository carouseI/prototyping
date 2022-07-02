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

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput; //set camera to track player movement on vertical axis
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //track horizontal movement
        moveDirection.Normalize(); //maintain direction vector + set length to 1
        moveDirection.y = 0; //lock player's vertical movement; ground player
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity; //move player according to calculations
    }
}
