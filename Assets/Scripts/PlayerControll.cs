using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //for left right rotation
    public float speedH = 2.0f;
    private float yaw = 0.0f;

    //for forward backwards movement
    public float speed = 2;
    Rigidbody rb;
    Vector3 rbMove;
    Quaternion rbRotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal mouse input
        //rotate player based on horizontal input (with rb)
        yaw = speedH * Input.GetAxis("Mouse X");
        rbRotate = Quaternion.Euler(new Vector3(0.0f, yaw * speedH, 0.0f) * Time.deltaTime);

        //key up and down input
        //move player forward/backward
        //get rb change here
        rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * speed * Time.deltaTime), 0, (Input.GetAxis("Horizontal") * -speed * Time.deltaTime)));
    }

    void FixedUpdate()
    {
        //update rb here
        rb.MoveRotation((rb.rotation * rbRotate).normalized);
        rb.MovePosition(transform.position + rbMove);
    }
}