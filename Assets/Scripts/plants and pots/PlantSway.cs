using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSway : MonoBehaviour
{
    public Plant plant;
    public float speed, max, min;
    public bool back;

    private Tempo globalTempo;

    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponent<Plant>();
        
        globalTempo = GameObject.FindGameObjectWithTag("Tempo").GetComponent<Tempo>();
        globalTempo.beat.AddListener(changeSway);
    }

    // Update is called once per frame
    void Update()
    {
        if (plant.isPlanted == true)
        {
            //Debug.Log("rotation = " + transform.rotation.x);
            //Debug.Log("Euler = " + transform.localEulerAngles);
            //start sway TODO sway keep rotating the plant more and more to one side, probable need to replace with animation
            if (back == false)
            {
                transform.Rotate(speed, 0, 0, Space.Self);
            }

            if (back == true)
            {
                transform.Rotate(-speed, 0, 0, Space.Self);
            }
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.World);
        } 
    }

    public void changeSway()
    {
        back = !back;
        /*  debug for plant swaying to one side too much
        if (plant.isPlanted == true)
        {
            if (back == false)
            {
                Debug.Log("forward x max = " + transform.rotation.x);
            }
            else
            {
                Debug.Log("backwards x max = " + transform.rotation.x);
            }
        }
        */
    }
}
