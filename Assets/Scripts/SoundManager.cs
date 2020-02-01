using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip footsteps;
    public float footstepTime;
    private float footstepDelay;

    public AudioClip shovel;
    public AudioClip plant;
    public AudioClip effort;
    public AudioClip collision;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    public void footStepsPlay()
    {
        if(footstepDelay + footstepTime < Time.time)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = footsteps;
                audioSource.Play();
                footstepDelay = Time.time;
            }
        }
    }

    public void footStepsStop()
    {
        audioSource.Stop();
        footstepDelay = Time.time;
    }

    public void shovelPlay()
    {
        audioSource2.PlayOneShot(shovel);
    }

    public void effortPlay()
    {
        audioSource2.PlayOneShot(effort);
    }

    public void plantPlay()
    {
        audioSource2.PlayOneShot(plant);
    }

    public void collisionPlay()
    {
        audioSource2.PlayOneShot(collision);
    }
}
