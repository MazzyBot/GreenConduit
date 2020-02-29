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
            //start sway
            if (back == false)
            {
                transform.Rotate(speed * Time.deltaTime, 0, 0, Space.Self);
                //Debug.Log("pos speed");
            }


            if (back == true)
            {
                transform.Rotate(-speed * Time.deltaTime, 0, 0, Space.Self);
                //Debug.Log("neg speed");
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
    }
}
