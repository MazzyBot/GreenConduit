using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //audio stuff
    private AudioRandomiser sounds;

    public string plantType;    //PLACE HOLDER TEMP

    public PotTypes potType;
    public bool isPlanted;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioRandomiser>();
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
                Debug.Log("play music of plant type " + plantType + " with pot type " + potType);
                sounds.StartMusic(potType);
            }
        }
        else
        if(isPlanted == true && (transform.parent == null || transform.parent.gameObject.CompareTag("player")))
        {
            isPlanted = false;
            potType = PotTypes.Empty;
            Debug.Log("stop music of " + plantType + " plant");
            sounds.StopMusic();
        }
    }
}
