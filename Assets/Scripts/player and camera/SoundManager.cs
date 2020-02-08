using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] footsteps;

    public AudioClip[] shovel;
    public AudioClip plant;
    public AudioClip[] effort;
    public AudioClip collision;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    public void footStepPlay()
    {
        audioSource2.PlayOneShot(GetRandomSound(footsteps));
    }

    public void shovelPlay()
    {
        audioSource2.PlayOneShot(GetRandomSound(shovel));
    }

    public void effortPlay()
    {
        audioSource2.PlayOneShot(GetRandomSound(effort));
    }

    public void plantPlay()
    {
        audioSource2.PlayOneShot(plant);
    }

    public void collisionPlay()
    {
        effortPlay();
    }

    private AudioClip GetRandomSound(AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
