using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //audio stuff
    private AudioRandomiser sounds;

    public string plantType;    //used when RND generation of plants

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
        if (transform.parent != null && isPlanted == false) //if it has a parent and it isnt planted
        {
            if (transform.parent.transform.gameObject.CompareTag("pot"))    //if parent is a pot, play music
            {
                isPlanted = true;
                potType = transform.parent.transform.gameObject.GetComponent<Pot>().potType;
                sounds.StartMusic(potType);
            }
        }
        else
        if(isPlanted == true && (transform.parent == null || transform.parent.gameObject.CompareTag("player"))) //if it was planted, but its parent isnt a pot(player or nothing) stop music
        {
            isPlanted = false;
            potType = PotTypes.Empty;
            sounds.StopMusic();
        }
    }
}

