using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;

    public Vector2 movementInput; //variables set on 2 axes -- left + right; up + down
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null) //if not filled in
        {
            playerControls = new PlayerControls(); //set variable to new control setup

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //record movement to vector2 variable
        }

        playerControls.Enable();
    }

    private void OnDisable() //if attached object is disabled
    {
        playerControls.Disable(); //turn off player controls
    }


    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)); //clamp value between 0 + 1; abs = set to positive
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}