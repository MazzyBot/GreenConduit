using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public PlayerPickUpPutDown pickUpPutDown;

    private readonly string scoopTrigger = "Scoop";
    private readonly string placeTrigger = "PlaceTrigger";
    private readonly string movingSpeed = "WalkSpeed";
    private readonly string isMoving = "IsMoving";

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
    }

    public void DoScoop()
    {
        anim.SetTrigger(scoopTrigger);
    }

    public void DoPlace()
    {
        anim.SetTrigger(placeTrigger);
    }

    public void SetVelocity(float vel)
    {
        anim.SetBool(isMoving, vel != 0);
        anim.SetFloat(movingSpeed, vel);
    }

    public void Scoop()
    {
        Debug.Log("Scoop");
        pickUpPutDown.DoPickUp();
    }

    public void Place()
    {
        Debug.Log("Place");
        pickUpPutDown.DoPlace();
    }

    //public void FootstepEvent()
    //{
    //    sounds.PlaySound("Footstep");
    //}
}
