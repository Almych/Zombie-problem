using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Level Config", menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public string Title;
    public string Description;
    public LevelDay levelDay;
    public WaveConfig WavesConfig;
    public CollectableConfig CollectablesConfig;
    public LevelCompleteStats levelRequirements;

    public int LevelId;
    public bool IsCompleted => StarsEarned > 0;
    public bool IsOpen { get; private set; }
    public int StarsEarned { get; private set; }

    public bool IdAssigned;

    public void SetId(int id, bool force = false)
    {
        if (!IdAssigned || force)
        {
            LevelId = id;
            IdAssigned = true;
            IsOpen = false;
        }
    }

    public void LoadProgress()
    {
        StarsEarned = SaveSystem.LoadStars(LevelId);
        IsOpen = LevelId <= SaveSystem.LoadUnlockedLevel();
    }

    public bool TryOpen(int levelReached)
    {
        IsOpen = LevelId <= levelReached;
        return IsOpen;
    }

    public void CompleteLevel(int stars)
    {
        SaveSystem.SaveStars(LevelId, stars);
        SaveSystem.SaveUnlockedLevel(LevelId + 1);
        LoadProgress(); // Refresh locally
    }
}

public enum LevelDay { Day, Night, Evening }

[Serializable]
public struct LevelCompleteStats
{
    [Range(1, 100)] public int threeStarsDamage;
    [Range(1, 100)] public int twoStarsDamage;
    [Range(1, 100)] public int oneStarsDamage;
}
