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

    [SerializeField] private int levelId;
    [SerializeField] private bool idAssigned;
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isCompleted;
    [SerializeField] private int starsEarned;

    public int LevelId => levelId;
    public bool IsOpen => isOpen;
    public bool IsCompleted => isCompleted;
    public int StarsEarned => starsEarned;
    public bool IdAssigned => idAssigned;

    public void SetId(int id, bool force = false)
    {
        if (!idAssigned || force)
        {
            levelId = id;
            idAssigned = true;
            isOpen = false;
        }
    }

    public void CompleteLevel(int stars)
    {
        isCompleted = true;
        starsEarned = stars;
        Debug.Log($"level config {name}, level id {levelId} completed {isCompleted}, stars {stars}");
    }

    public void TryOpen(int currentLevel)
    {
        if (!isOpen && currentLevel >= levelId)
            isOpen = true;
    }
}

public enum LevelDay { Day, Night, Evening }

[Serializable]
public struct LevelCompleteStats
{
    [Range(0, 100)] public int threeStarsDamage;
    [Range(0, 100)] public int twoStarsDamage;
    [Range(0, 100)] public int oneStarsDamage;
}
