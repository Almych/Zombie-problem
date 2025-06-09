using UnityEngine;
public struct LevelStats
{
    public float TimeSpent;
    public int ZombiesKilled;
    public int DamageTaken;
}
public class LevelStatsTracker : IStatsTracker
{
    private LevelStats _stats = new LevelStats();
    private float _timer;

    public void OnStart()
    {
        _timer = 0f;
        _stats = new LevelStats();
    }

    public void OnUpdate(float deltaTime)
    {
        _timer += deltaTime;           
    }

    public void OnDamageTaken(int amount)
    {
        _stats.DamageTaken += amount;
    }



    public void OnFinish()
    {
        _stats.TimeSpent = _timer;
    }

    public LevelStats GetResults() => _stats;
}

