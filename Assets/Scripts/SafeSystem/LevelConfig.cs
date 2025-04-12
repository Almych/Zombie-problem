
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Config", menuName ="LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public string Title, Description;
    public LevelDay levelDay;
    public WaveConfig WavesConfig;
    public CollectableConfig CollectablesConfig;
    public int levelStars;
    public bool levelComplete {get; private set;}
    public bool levelOpen { get; private set;}
    public int levelId { get; set; }
    public bool idAssigned;


    public void SetId(int id)
    {
        levelId = id;
        Debug.Log(levelId);
        idAssigned = true;
    }
    public void CompleteLevel()
    {
        levelComplete = true;
    }

    public void TryOpenLevel(int level)
    {
        if(level >= levelId)
        {
            levelOpen = true;
        }
        
    }
}

public enum LevelDay
{
    Day,
    Night,
    Evening
};
