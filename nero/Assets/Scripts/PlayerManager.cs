using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class PlayerManager : MonoBehaviour
    {
        PlayerCamera playerCamera;
        InputManager inputManager;

        private void Awake()
        {
            playerCamera = FindObjectOfType<PlayerCamera>();
            inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            inputManager.HandleAllInput();
        }

        private void LateUpdate()
        {
            playerCamera.HandleAlleCameraMovement();
        }
    }
}