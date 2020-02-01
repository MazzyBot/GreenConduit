using UnityEngine;

[System.Serializable]
public class PlantSongs
{
    [Range(0f, 1f)]
    public float clipVolume;

    public PlantSongVariation busyClips;
    public PlantSongVariation mediumClips;
    public PlantSongVariation calmClips;

    public PlantSongVariation GetVariation(PotTypes type)
    {
        if (type == PotTypes.Empty)
        {
            throw new System.Exception("Cannot play an empty pot type!");
        }

        switch (type)
        {
            case PotTypes.Busy:
                return busyClips;
            case PotTypes.Medium:
                return mediumClips;
            case PotTypes.Calm:
                return calmClips;
            case PotTypes.Empty:
                break;
        }
        return calmClips;
    }
}
