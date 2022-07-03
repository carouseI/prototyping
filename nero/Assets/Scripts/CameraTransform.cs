using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
