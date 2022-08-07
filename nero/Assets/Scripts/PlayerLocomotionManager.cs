using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionManager : MonoBehaviour
{
    InputManager inputManager;

    [Header("Camera Transform")]
    public Transform playerCamera;

    [Header("Movement Speed")]
    public float rotationSpeed = 3.5f;

    [Header("Rotation Variables")]
    Quaternion targetRotation;
    Quaternion playerRotation;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    public void HandleAllLocomotion()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        targetRotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0); //only rotate towards 1 direction/where camera is facing
        playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if(inputManager.verticalMovementInput != 0 || inputManager.horizontalMovementInput != 0) //only rotate when there is movement input
        {
            transform.rotation = playerRotation;
        }
    }
}
