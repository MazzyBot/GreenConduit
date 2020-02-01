using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{
    public PlantSongs songs;
    private AudioClip[] currentClips;

    AudioSource source;

    private bool startedPlaying;

    private AudioSource SetUpSource(AudioClip clip)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip;
        //source.loop = true;
        return source;
    }

    public void StartMusic(PotTypes songType)
    {
        PlantSongVariation variation = songs.GetVariation(songType);
        currentClips = variation.variations;

        source = SetUpSource(variation.startingClip);
        source.Play();
        startedPlaying = true;
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
}
