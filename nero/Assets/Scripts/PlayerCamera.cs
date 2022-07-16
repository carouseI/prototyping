using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class PlayerCamera : MonoBehaviour
    {
        public Transform cameraPivot;
        public Camera cameraObject;
        public GameObject player;

        Vector3 cameraFollowVelocity = Vector3.zero;
        Vector3 targetPosition;

        [Header("Camera Speeds")]
        public float cameraSmoothTime = 0.2f;

        public void HandleAlleCameraMovement()
        {
            //follow player
            //rotate camera
        }

        private void FollowPlayer()
        {
            targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraFollowVelocity, cameraSmoothTime * Time.deltaTime); //smoothDamp @ current player position w/ camera follow velocity
            transform.position = targetPosition;
        }
    }
}