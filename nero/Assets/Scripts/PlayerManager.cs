using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class PlayerManager : MonoBehaviour
    {
        PlayerCamera playerCamera;
        InputManager inputManager;
        PlayerLocomotion playerLocomotion;

        private void Awake()
        {
            playerCamera = FindObjectOfType<PlayerCamera>();
            inputManager = GetComponent<InputManager>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        private void Update()
        {
            inputManager.HandleAllInput();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate()
        {
            playerCamera.HandleAllCameraMovement();
        }
    }
}