using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] footsteps;

    public AudioClip[] shovel;
    public AudioClip plant;
    public AudioClip[] effort;

    public AudioSource audioSource;

    public void footStepPlay()
    {
        audioSource.PlayOneShot(GetRandomSound(footsteps));
    }

    public void shovelPlay()
    {
        audioSource.PlayOneShot(GetRandomSound(shovel));
    }

    public void effortPlay()
    {
        audioSource.PlayOneShot(GetRandomSound(effort));
    }

    public void plantPlay()
    {
        audioSource.PlayOneShot(plant);
    }

    private AudioClip GetRandomSound(AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
