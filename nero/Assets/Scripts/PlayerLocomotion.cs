using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorManager animatorManager;

    [SerializeField]
    public float movementSpeed = 7;
    [SerializeField]
    public float rotationSpeed = 15;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        animatorManager = GetComponent<AnimatorManager>();
        cameraObject = Camera.main.transform; //scan scene for default camera tag
        myTransform = transform;
    }

    public void Update()
    {
        float delta = Time.deltaTime;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
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

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward; //set rotation to position when player stops movement

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //quaternion = unity rotation calculations
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //slerp = rotation between point A + B

        transform.rotation = playerRotation;
    }
}
