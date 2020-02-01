using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFlag : MonoBehaviour
{
    public int rndSeed;
    int plantNumber;
    Quaternion rndRotation;

    public GameObject[] plants;

    // Start is called before the first frame update
    void Start()
    {
        //run rnd from seed
        //create plant
        //distroy flag

        float temp = rndSeed * Random.value;
        rndSeed = (int) temp;
        Random.InitState(rndSeed);
        plantNumber = Random.Range(0, 8) / 2;
        rndRotation = Quaternion.Euler(0, Random.Range(0, 360) * Random.value, 0);

        Instantiate(plants[plantNumber], transform.position, rndRotation);

        Destroy(gameObject);
    }
}
