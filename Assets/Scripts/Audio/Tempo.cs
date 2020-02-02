using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Tempo class for starting and stopping tempo. Keeps the beat.
/// </summary>
public class Tempo : MonoBehaviour
{
    public float BPM;

    // Unity Event stuff
    public UnityEvent beat;
    
    private bool hasStarted;
    private double secsPerBeat;
    private double startTime;
    private double currentBeatTime;
    private double nextBeatTime;

    private void Start()
    {
        if (beat == null)
            beat = new UnityEvent();
        SetTempo(TempoUtils.FlipBpmInterval(BPM));
        StartTempo();
    }

    /// <summary>
    /// Sets the tempo. Please call StartTempo() afterwards to start it.
    /// </summary>
    /// <param name="secondInterval">the interval between each beat in seconds</param>
    public void SetTempo(double secondInterval)
    {
        secsPerBeat = secondInterval;
    }

    /// <summary>
    /// Starts the tempo. Will throw an exception if you haven't called SetTempo() yet.
    /// </summary>
    public void StartTempo()
    {
        if (secsPerBeat == 0)
        {
            throw new System.Exception("You can't start the tempo without a tempo! Please set the tempo prior to starting!");
        }
        else
        {
            startTime = AudioSettings.dspTime;
            currentBeatTime = startTime;
            hasStarted = true;
        }
    }

    /// <summary>
    /// Stops the tempo from doing it's thang and resets some values.
    /// </summary>
    public void StopTempo()
    {
        hasStarted = false;
        startTime = 0;
        currentBeatTime = 0;
    }

    private void FixedUpdate()
    {
        // maybe coroutines with yield could work better? need to test
        if (hasStarted)
        {
            double currentTime = AudioSettings.dspTime;
            bool hasGonePastBeat = false;
            while (currentTime > currentBeatTime + secsPerBeat)
            {
                hasGonePastBeat = true;
                currentBeatTime += secsPerBeat;
                nextBeatTime = currentBeatTime + secsPerBeat;
            }
            if (hasGonePastBeat)
            {
                Beat();
            }
        }
    }

    /// <summary>
    /// Called when the beat is hit
    /// </summary>
    private void Beat()
    {
        // calls the delegate method if there are listeners
        if (beat != null)
            beat.Invoke();
    }
}
