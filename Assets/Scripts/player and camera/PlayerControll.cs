using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //ground check
    public bool onGround;
    public bool onGroundColli;
    public float groundCheckDistance = 0.51f;

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

    public AnimationControllerTest anim;    //remove 'Test' from this when reverting

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
        float axisV = Input.GetAxis("Vertical");
        if (onGround == true)   //if on ground allow horiziontal movement and footsteps
        {
            if (axisV > 0)
            {
                rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * speedMove * Time.deltaTime), 0, 0));
            }
            else if (axisV < 0)
            {
                rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * (speedMove / 3) * Time.deltaTime), 0, 0));
            }
            else
            {
                rbMove = transform.rotation * (new Vector3(0, 0, 0));
            }
            anim.SetVelocity(rbMove.x);
        }
        else    //make its current vector run its course, and stop footsteps
        {
            //rbMove = rbMove;  //what currently it is when ground is false
            anim.SetVelocity(0);
        }

        //check ground if on ground collide is false, else it must be on ground
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, groundCheckDistance);
        if (onGroundColli == false) //could get rid of secoundary check now
        {
            if (hit.collider != null && hit.collider.CompareTag("ground"))
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
        else
        {
            onGround = true;
        }
    }

    void FixedUpdate()
    {
        //update rb here
        
        rb.MoveRotation((rb.rotation * rbRotate).normalized);
        rb.MovePosition(transform.position + rbMove);

        //transform.SetPositionAndRotation(transform.position + rbMove, (rb.rotation * rbRotate).normalized);
    }

    void OnCollisionEnter(Collision collision)  //collision sounds
    {
        //Debug.Log("colliding with " + collision.gameObject.name);
        if (!collision.gameObject.CompareTag("ignore for sound") && !collision.gameObject.CompareTag("ground") && !collision.gameObject.CompareTag("grass"))
        {
            sound.collisionPlay();
        }
    }

    //on ground collide exit/entry
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGroundColli = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGroundColli = false;
        }
    }
}