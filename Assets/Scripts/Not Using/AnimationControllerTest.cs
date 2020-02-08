using UnityEngine;

public class AnimationControllerTest : MonoBehaviour
{
    private Animator anim;
    public pickUpAndDownRayCast pickUpPutDown;
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

    public void SetVelocity(float vel)
    {
        anim.SetBool(isMoving, vel != 0);
        anim.SetFloat(movingSpeed, vel);
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
