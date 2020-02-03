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
        float axisV = Input.GetAxis("Vertical");
        if (axisV > 0)
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * speedMove * Time.deltaTime), 0, 0));
            sound.footStepsPlay();
        }
        else if (axisV < 0)
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * (speedMove / 3) * Time.deltaTime), 0, 0));
            sound.footStepsPlay();
        }
        else
        {
            rbMove = transform.rotation * (new Vector3((Input.GetAxis("Vertical") * (speedMove / 3) * Time.deltaTime), 0, 0));
            sound.footStepsStop();
        }
        anim.SetVelocity(rbMove.x);
    }

    void FixedUpdate()
    {
        //update rb here
        rb.MoveRotation((rb.rotation * rbRotate).normalized);
        rb.MovePosition(transform.position + rbMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colliding with " + collision.gameObject);
        if (!collision.gameObject.CompareTag("ignore for sound"))
        {
         sound.collisionPlay();
        }
    }
}