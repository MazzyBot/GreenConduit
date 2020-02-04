using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpPutDown : MonoBehaviour
{
    public GameObject plant;
    public GameObject pot;
    public GameObject holding;

    public GameObject plantAnkPoint;

    public Vector3 placePosition;
    public float potPlacementHeight;

    //Sound manager
    SoundManager sound;
    public AnimationController anim;
    public bool canInput = true;
    public bool potting;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //get space input
        
        //if not holding an item && if plant is there pick up 
        //else
        //put down if holding an item

        //if close to plant spot
        //put down at spot
        //else
        //just place on ground

        if (Input.GetButtonDown("Jump") && canInput)
        {
            if (holding == null)
            {
                if (plant != null)
                {
                    // turn off the collision here
                    // can have another animation event at the end to trigger a function that turns the collider on again
                    holding = plant;
                    holding.GetComponent<Collider>().isTrigger = true;
                    canInput = false;
                    anim.DoScoop();
                }
            }
            else 
            if (holding != null)
            {
                if (pot != null)    //so only one plant can be placed per pot
                {
                    potting = pot.GetComponent<Pot>().isFull != true;
                    if (potting == true)    //can not place when in front of full pot
                    {
                        canInput = false;
                        anim.DoPlace();
                    }
                }
                else
                {
                    canInput = false;
                    anim.DoPlace();
                }
            }
        }
    }

    void OnTriggerStay(Collider collider)   //on trigger stay to keep upto date info and to avoid not being able to pick up due to vars being dumped
    {
        //on plant enter get plant and set pick up to true
        //on plantspot enter get info and set putdown to true(use null instead of bool?)
        if (collider.CompareTag("plant"))
        {
            plant = collider.gameObject;
        }
        
        if (collider.CompareTag("pot"))
        {
            pot = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        //on plant exit set dump plant info and set pick up to false
        //on plantspot exit dump info and set plantspot to false(use null instead of bool?)
        if (collider.CompareTag("pot") && canInput == true)
        {
            Debug.Log("Pot dumped : on collider exit");
            pot = null;
        }
        else if (collider.CompareTag("plant"))
        {
            plant = null;
        }
    }

    public void DoPickUp()
    {
        sound.effortPlay();
        sound.shovelPlay();
        if (holding.transform.parent != null && holding.transform.parent.gameObject.CompareTag("pot"))  //check if in pot, if so isFull = false
        {
            holding.transform.parent.GetComponent<Pot>().isFull = false;
        }
        holding.transform.parent = plantAnkPoint.transform;
        holding.transform.localPosition = plantAnkPoint.transform.localPosition;
        StartCoroutine(FixHolding());
        canInput = true;
    }

    public void DoPlace()
    {
        holding.transform.rotation = Quaternion.identity;
        sound.effortPlay();
        sound.plantPlay();

        if (potting)
        {
            pot.GetComponent<Pot>().isFull = true;  //set pot isFull to true
            holding.transform.parent = pot.transform;
            holding.transform.position = new Vector3(pot.transform.position.x, potPlacementHeight, pot.transform.position.z);
        }
        else
        {
            holding.transform.parent = null;
            holding.transform.position = transform.position + (transform.rotation * placePosition);
        }
    }

    public void FinishPlace()
    {
        if (holding != null)
        {
            holding.GetComponent<Collider>().isTrigger = false;
            holding = null;
        }
        canInput = true;
    }

    IEnumerator FixHolding()
    {
        for (int i = 0; i < 40; i++)
        {
            var step = 500 * Time.deltaTime;
            Quaternion rot = holding.transform.rotation;
            holding.transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, rot.eulerAngles.y, 0), step);
            yield return null;
        }
    }

}
