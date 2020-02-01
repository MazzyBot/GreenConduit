using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{
    public PlantSongs songs;
    private AudioClip[] currentClips;

    AudioSource source;

    private bool startedPlaying;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void StartMusic(PotTypes songType)
    {
        PlantSongVariation variation = songs.GetVariation(songType);
        currentClips = variation.variations;
        source.clip = variation.startingClip;

        // make it be triggered by the tempo
        Tempo.OnBeat += DoBeat;
    }

    public void StopMusic()
    {
        source.Stop();
        startedPlaying = false;
    }

    private void Update()
    {
        if (startedPlaying && !source.isPlaying)
        {
            SwapSongs(source);
        }
    }

    private void SwapSongs(AudioSource source)
    {
        source.clip = GetRandomClip();
        source.Play();
    }

    private AudioClip GetRandomClip()
    {
        return currentClips[Random.Range(0, currentClips.Length)];
    }

    // syncing stuff
    private void DoBeat()
    {
        source.Play();
        startedPlaying = true;
        // remove it from being triggered by the tempo
        Tempo.OnBeat -= DoBeat;
    }
}
