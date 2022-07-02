using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    public Vector2 movementInput; //variables set on 2 axes -- left + right; up + down

    private void OnEnable()
    {
        if(playerControls == null) //if not filled in
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
}
