using UnityEngine;

public class BeatPlayer : MonoBehaviour
{
    private AudioSource source;
    public Tempo tempo;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        tempo.beat.AddListener(PlayThing);
    }

    void OnDisable()
    {
        tempo.beat.RemoveListener(PlayThing);
    }

    private void PlayThing()
    {
        source.Play();
    }
}
