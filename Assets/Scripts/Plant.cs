using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //audio stuff

    public string plantType;    //PLACE HOLDER TEMP

    public string potType;
    public bool isPlanted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null && isPlanted == false)
        {
            if (transform.parent.transform.gameObject.CompareTag("pot"))
            {
                isPlanted = true;
                potType = transform.parent.transform.gameObject.GetComponent<Pot>().potType;
                Debug.Log("play music of pot type " + plantType + " with potType " + potType);
            }
        }
        else
        if(isPlanted == true && (transform.parent == null || transform.parent.name == "Player"))
        {
            isPlanted = false;
            potType = null;
            Debug.Log("stop music of " + plantType + " plant");
        }
    }
}
