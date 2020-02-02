using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{
    public PlantSongs songs;
    private AudioClip[] currentClips;

    private AudioSource sourceOne;
    private AudioSource sourceTwo;
    private bool usingSourceOne;

    private Tempo globalTempo;
    private Tempo variationTempo;

    private void Start()
    {
        sourceOne = gameObject.AddComponent<AudioSource>();
        sourceOne.playOnAwake = false;
        sourceTwo = gameObject.AddComponent<AudioSource>();
        sourceTwo.playOnAwake = false;

        globalTempo = GameObject.FindGameObjectWithTag("Tempo").GetComponent<Tempo>();
        variationTempo = gameObject.AddComponent<Tempo>();
    }

    private void OnDisable()
    {
        variationTempo.beat.RemoveListener(ClipSwap);
    }

    public void StartMusic(PotTypes songType)
    {
        PlantSongVariation variation = songs.GetVariation(songType);
        currentClips = variation.variations;
        sourceOne.clip = variation.startingClip;
        usingSourceOne = false;

        variationTempo.SetTempo(variation.startingClip.length);
        variationTempo.beat.AddListener(ClipSwap);

        // make it be triggered by the tempo
        globalTempo.beat.AddListener(DoBeat);
    }

    public void StopMusic()
    {
        sourceOne.Stop();
        sourceTwo.Stop();
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
        sourceOne.Play();

        // remove it from being triggered by the global tempo
        globalTempo.beat.RemoveListener(DoBeat);

        // start our own tempo to make the clip swapping stay in time
        variationTempo.StartTempo();
    }

    private void ClipSwap()
    {
        SwapSongs(usingSourceOne ? sourceOne : sourceTwo);
        usingSourceOne = !usingSourceOne;
    }
}
