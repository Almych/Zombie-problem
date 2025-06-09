using UnityEngine;
public interface IStatsTracker
{
    void OnStart();
    void OnUpdate(float deltaTime);
    void OnDamageTaken(int amount);
    void OnFinish();
    LevelStats GetResults();
}
