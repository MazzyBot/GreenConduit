using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public PlayerPickUpPutDown pickUpPutDown;
    public SoundManager sounds;

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

    public void SetVelocity(float vel, float moveInput)
    {
        anim.SetBool(isMoving, vel != 0);
        // multiplies the speed animation speed. -1 to move backwards
        anim.SetFloat(movingSpeed, moveInput);
    }

    public void Scoop()
    {
        pickUpPutDown.DoPickUp();
    }

    public void Place()
    {
        pickUpPutDown.DoPlace();
    }

    public void EnablePlantCollider()
    {
        pickUpPutDown.FinishPlace();
    }

    public void Footstep()
    {
        sounds.footStepPlay();
    }
}
