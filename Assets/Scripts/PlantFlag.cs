using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFlag : MonoBehaviour
{
    public int rndSeed;

    public GameObject[] plants;

    // Start is called before the first frame update
    void Start()
    {
        //run rnd from seed
        //create plant
        //distroy flag

        Random.InitState(rndSeed);
        Debug.Log("Random State = " + Random.state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
