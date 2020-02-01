using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPlayer : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Tempo.OnBeat += PlayThing;
    }

    void OnDisable()
    {
        Tempo.OnBeat -= PlayThing;
    }

    private void PlayThing()
    {
        source.Play();
    }
}
