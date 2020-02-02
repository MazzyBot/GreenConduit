using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerObject;
    public float followSpeed;
    public float cameraRotateSpeed;
    public Vector3 followOffset;
    public bool lockBehind;

    // greenhouse stuff
    public bool followingPlayer;
    public Transform greenhouseLoco;
    public float greenhouseHeight;
    public float greenhouseTransitionSpeed;
    public Vector3 greenhouseCameraRotation;
    
    private Rigidbody playerRb;
    private float currentY;

    void Start()
    {
        playerRb = playerObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (followingPlayer && !lockBehind)
        {
            //horizontal mouse input for cam rotation
            currentY += cameraRotateSpeed * Input.GetAxis("Mouse X");
        }
    }

    void FixedUpdate()
    {
        Vector3 vel = playerRb.velocity;
        if (followingPlayer)
        {
            //move to set Offset position behind Player
            if (!lockBehind)
            {
                Quaternion rotation = Quaternion.Euler(0, currentY, 0);
                transform.position = Vector3.SmoothDamp(transform.position, playerObject.transform.position + rotation * followOffset, ref vel, followSpeed * 0.1f);
                transform.LookAt(playerObject.transform.position);
            }
            else
            if (lockBehind)
            {
                Quaternion rotation = Quaternion.Euler(0, playerObject.transform.eulerAngles.y, 0);
                transform.position = Vector3.SmoothDamp(transform.position, playerObject.transform.position + rotation * followOffset, ref vel, followSpeed * 0.1f);
                transform.LookAt(playerObject.transform.position);
            }
        }
        else
        {
            // in the greenhouse
            transform.position = Vector3.SmoothDamp(transform.position, greenhouseLoco.position + new Vector3(0, greenhouseHeight, 0), ref vel, 0.1f);
            //float step = greenhouseTransitionSpeed * Time.fixedDeltaTime;
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(greenhouseCameraRotation), step);
            transform.LookAt(playerObject.transform.position);
        }
    }
}
