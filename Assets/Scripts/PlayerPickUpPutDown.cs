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

        if (Input.GetButtonDown("Jump"))
        {
            if (holding == null)
            {
                if (plant != null)
                {
                    holding = plant;
                    holding.transform.parent = plantAnkPoint.transform;
                    holding.transform.localPosition = plantAnkPoint.transform.localPosition;
                    sound.effortPlay();
                    sound.shovelPlay();
                }
            }
            else 
            if (holding != null)
            {
                if (pot != null)
                {
                    holding.transform.parent = pot.transform;
                    holding.transform.position = new Vector3(pot.transform.position.x, potPlacementHeight, pot.transform.position.z);
                    holding = null;
                    sound.effortPlay();
                    sound.plantPlay();
                }
                else
                {
                    holding.transform.localPosition = placePosition;
                    holding.transform.parent = null;
                    holding = null;
                    sound.effortPlay();
                    sound.plantPlay();
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //on plant enter get plant and set pick up to true
        //on plantspot enter get info and set putdown to true(use null instead of bool?)
        GameObject temp = collider.gameObject;
        
        if (temp.CompareTag("plant"))
        {
            plant = temp;
        }
        
        if (temp.CompareTag("pot"))
        {
            pot = temp;
        }

    }

    void OnTriggerExit(Collider collider)
    {
        //on plant exit set dump plant info and set pick up to false
        //on plantspot exit dump info and set plantspot to false(use null instead of bool?)
        plant = null;
        pot = null;
    }
}
