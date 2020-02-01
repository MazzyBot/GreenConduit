using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //for left right rotation
    public float speedTurn = 10.0f;
    private float yawTurn = 0.0f;

    //for forward backwards movement
    public float speedMove = 5;
    Rigidbody rb;
    Vector3 rbMove;
    Quaternion rbRotate;

    //camera rotation
    public float speedCam = 8.0f;
    private float yawCam = 0.0f;
    public GameObject camRotatePoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal mouse input for cam rotation
        yawCam = speedCam * Input.GetAxis("Mouse X");
        camRotatePoint.transform.Rotate(0.0f, yawCam * speedCam * Time.deltaTime, 0.0f, Space.Self);


        //rotate player based on horizontal input (with rb)
        yawTurn = speedTurn * Input.GetAxis("Horizontal");
        rbRotate = Quaternion.Euler(new Vector3(0.0f, yawTurn * speedTurn, 0.0f) * Time.deltaTime);

        //key up and down input
        //move player forward/backward
        //get rb change here
        rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * speedMove * Time.deltaTime), 0, 0));
    }

    void FixedUpdate()
    {
        //update rb here
        rb.MoveRotation((rb.rotation * rbRotate).normalized);
        rb.MovePosition(transform.position + rbMove);
    }
}