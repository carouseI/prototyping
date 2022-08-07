using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraPivot;
    public Camera cameraObject;
    public GameObject player;

    Vector3 cameraFollowVelocity = Vector3.zero;
    Vector3 targetPosition;

    [Header("Camera Speed")]
    public float cameraSmoothTime = 0.2f;

    public void HandleAllCameraMovement()
    {

    }

    private void FollowPlayer()
    {
        targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraFollowVelocity, cameraSmoothTime * Time.deltaTime); //targetPos @ playerPos + ref from camera
        transform.position = targetPosition;
    }
}
