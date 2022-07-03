using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class PlayerManager : MonoBehaviour
    {
        InputManager inputManager;
        CameraManager cameraManager;
        PlayerLocomotion playerLocomotion;

        public void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>(); //check for object with locomotion comp

            Cursor.visible = false;
        }

        private void Update()
        {
            inputManager.HandleAllInput();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();
        }
    }
}