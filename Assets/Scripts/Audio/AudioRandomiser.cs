using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{
    public PlantSongs songs;
    private AudioClip[] currentClips;

    private AudioSource theSource;

    private Tempo globalTempo;
    private Tempo variationTempo;

    private void Start()
    {
        theSource = GetComponent<AudioSource>();
        if (theSource == null)
        {
            theSource = gameObject.AddComponent<AudioSource>();
        }
        theSource.playOnAwake = false;

        globalTempo = GameObject.FindGameObjectWithTag("Tempo").GetComponent<Tempo>();
        variationTempo = gameObject.AddComponent<Tempo>();

        theSource.volume = songs.clipVolume;
    }

    private void OnDisable()
    {
        variationTempo.beat.RemoveListener(ClipSwap);
    }

    public void StartMusic(PotTypes songType)
    {
        PlantSongVariation variation = songs.GetVariation(songType);
        currentClips = variation.variations;
        theSource.clip = variation.startingClip;

        variationTempo.SetTempo(variation.startingClip.length);
        variationTempo.beat.AddListener(ClipSwap);

        // make it be triggered by the tempo
        globalTempo.beat.AddListener(DoBeat);
    }

    public void StopMusic()
    {
        theSource.Stop();
        variationTempo.StopTempo();
    }

    private void SwapSongs(AudioSource source)
    {
        source.clip = GetRandomClip();
        source.Play();
    }

    private AudioClip GetRandomClip()
    {
        if (currentClips.Length > 0)
            return currentClips[Random.Range(0, currentClips.Length)];
        return null;
    }

    // syncing stuff
    private void DoBeat()
    {
        theSource.Play();

        // remove it from being triggered by the global tempo
        globalTempo.beat.RemoveListener(DoBeat);

        // start our own tempo to make the clip swapping stay in time
        variationTempo.StartTempo();
    }

    private void ClipSwap()
    {
        SwapSongs(theSource);
    }
}
