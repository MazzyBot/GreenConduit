using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip footsteps;
    public float footstepTime;
    private float footstepLastPlayed;

    public AudioClip shovel;
    public AudioClip plant;
    public AudioClip effort;
    public AudioClip collision;

    public void footStepsPlay()
    {
        if(footstepLastPlayed + footstepTime < Time.time)
        {
            GameObject soundGameObject = new GameObject("sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(footsteps);
            footstepLastPlayed = Time.time;
        }
    }

    public void shovelPlay()
    {
        GameObject soundGameObject = new GameObject("sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(shovel);
    }

    public void effortPlay()
    {
        GameObject soundGameObject = new GameObject("sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(effort);
    }

    public void plantPlay()
    {
        GameObject soundGameObject = new GameObject("sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(plant);
    }

    public void collisionPlay()
    {
        GameObject soundGameObject = new GameObject("sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(collision);
    }
}
