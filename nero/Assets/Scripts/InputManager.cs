using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class InputManager : MonoBehaviour
    {
        PlayerControls playerControls;
        AnimatorManager animatorManager;

        [Header("Player Movement")]
        public float verticalMovementInput;
        public float horizontalMovementInput;
        private Vector2 movementInput; //raw input fetched from player constrols; vector2 (split in 2 -- vertical/horizontal) = store info on 2 axis; up/down, left/right

        [Header("Camera Rotation")]
        public float verticalCameraInput;
        public float horizontalCameraInput;
        private Vector2 cameraInput;

        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>(); //check for animator manager comp
        }

        private void OnEnable()
        {
            if (playerControls == null) //if null
            {
                playerControls = new PlayerControls(); //use new control setup

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //when key is hit, record movement to movementInput variable
                playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); //link mouse movement to camera input
            }

            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable(); //turn off player controls when gameObject is disabled
        }

        public void HandleAllInput()
        {
            HandleMovementInput();
            HandleCameraInput();
        }

        private void HandleMovementInput()
        {
            verticalMovementInput = movementInput.y; //give value of movement input on y-axis, up/down
            horizontalMovementInput = movementInput.x; //left: -1, right: +1, nothing = 0
            animatorManager.HandleAnimatorValues(horizontalMovementInput, verticalMovementInput); //pass through vert/hori input, edit anim values depending on frequency on keys pressed        }
        }

        private void HandleCameraInput()
        {
            verticalCameraInput = cameraInput.y;
            horizontalCameraInput = cameraInput.x;
        }
    }
}