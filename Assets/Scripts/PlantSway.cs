using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSway : MonoBehaviour
{
    public Plant plant;
    public float speed, max, min;
    public bool back;

    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponent<Plant>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("current angle = " + transform.eulerAngles.x);
        if(plant.isPlanted == true)
        {
            //Debug.Log("rotation = " + transform.rotation.x);
            //start sway
            if (transform.rotation.x <= max &&  back == false)
            {
                transform.Rotate(speed, 0, 0, Space.World);
            }
            else
            {
                back = true;
            }


            if (transform.rotation.x >= min && back == true)
            {
                transform.Rotate(-speed, 0, 0, Space.World);
            }
            else
            {
                back = false;
            }

            if (transform.rotation.x <= min && transform.rotation.x >= max)
            {
                back = !back;
            }
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.World);
        }
    }
}
