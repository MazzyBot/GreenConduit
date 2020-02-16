using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //on ground check
    public bool onGround;
    public float reboundSpeed;    //when hiting something that takes player off the grounf, how much is rebound

    //for left right rotation
    public float speedTurn = 10.0f;
    private float yawTurn = 0.0f;

    //for forward backwards movement
    public float speedMove = 5;
    Rigidbody rb;
    Vector3 rbMove;
    Quaternion rbRotate;

    //Sound manager
    SoundManager sound;

    public AnimationController anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate player based on horizontal input (with rb)
        yawTurn = speedTurn * Input.GetAxis("Horizontal");
        rbRotate = Quaternion.Euler(new Vector3(0.0f, yawTurn * speedTurn, 0.0f) * Time.deltaTime);

        //key up and down input
        //move player forward/backward
        //get rb change here
            //why is this with rotation, and why doesnt position work?
        float axisV = Input.GetAxis("Vertical");
        if (axisV > 0 && onGround == true)
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * speedMove * Time.deltaTime), 0, 0));
        }
        else if (axisV < 0 && onGround == true)
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * (speedMove / 3) * Time.deltaTime), 0, 0));
        }
        else
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * (speedMove / 3) * Time.deltaTime), 0, 0));
        }
        anim.SetVelocity(rbMove.x);
    }

    void FixedUpdate()
    {
        //update rb here
        rb.MoveRotation((rb.rotation * rbRotate).normalized);
        rb.MovePosition(transform.position + rbMove);
    }

    void OnCollisionEnter(Collision collision)  //collision sounds
    {
        //Debug.Log("colliding with " + collision.gameObject.name);
        if (!collision.gameObject.CompareTag("ignore for sound") && !collision.gameObject.CompareTag("ground") && !collision.gameObject.CompareTag("grass"))
        {
             sound.collisionPlay();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
            Vector3 localForward = transform.rotation * -(Vector3.forward) * reboundSpeed;
            rbMove = transform.rotation * new Vector3(localForward.x, localForward.y, localForward.z);
        }
    }
}