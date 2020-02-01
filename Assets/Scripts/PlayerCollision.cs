using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //stop movement went colliding with obstacle
    void OnCollisionExit(Collision collision)
    {
        /*
        Debug.Log("collision");

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0.9f, 0.9f, 0.9f)));
        rb.MovePosition(transform.position * 0.9f);
        */
    }
}
