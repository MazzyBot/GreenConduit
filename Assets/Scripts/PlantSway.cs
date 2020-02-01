using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSway : MonoBehaviour
{
    public Plant plant;
    public float speed, max, min;
    bool back;

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
            //start sway
            Debug.Log("current angle = " + transform.eulerAngles.x);
            Debug.Log(360 + min);
            if (transform.eulerAngles.x < max && back == false)
            {
                transform.Rotate(speed, 0, 0, Space.Self);
            }
            else
            if (transform.eulerAngles.x >= 0 && transform.eulerAngles.x < 360 + min)
            {
                back = true;
                transform.Rotate(-speed, 0, 0, Space.Self);
            }
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.World);
        }
    }
}
