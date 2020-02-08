using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFlagParent : MonoBehaviour
{
    public int rndSeed;
    int plantNumber;
    Quaternion rndRotation;

    public GameObject plantParent;
    public GameObject[] plants;

    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < transform.childCount; i++)
        {
            float temp = rndSeed * Random.value;
            rndSeed = (int)temp;
            Random.InitState(rndSeed);
            plantNumber = Random.Range(0, 8) / 2;
            rndRotation = Quaternion.Euler(0, Random.Range(0, 360) * Random.value, 0);

            bool amountCheck = false;

            while (amountCheck == false)
            {
                int typeCount = 0;

                for (int j = 0; j < plantParent.transform.childCount; j++)
                {
                    if (plants[plantNumber].GetComponent<Plant>().plantType == plantParent.transform.GetChild(j).gameObject.GetComponent<Plant>().plantType)
                    {
                        typeCount++;
                    }
                }

                if (typeCount < (childCount / 4))
                {
                    amountCheck = true;
                }
                else
                {
                    plantNumber = Random.Range(0, 8) / 2;
                }
            }

            Instantiate(plants[plantNumber], transform.GetChild(i).position, rndRotation, plantParent.transform);

            Destroy(transform.GetChild(i).gameObject);
        }

        Destroy(gameObject);
    }
}
