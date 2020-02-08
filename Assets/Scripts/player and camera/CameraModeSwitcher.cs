using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeSwitcher : MonoBehaviour
{
    public CameraFollow cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            cam.followingPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            cam.followingPlayer = true;
        }
    }
}
