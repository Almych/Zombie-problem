using UnityEngine;

public class LevelSystem
{
    public float timer;
    public bool isPaused;
    public float totalGetHealth, totalTime;
    public void SetTimer()
    {
        if(!isPaused)
        timer += Time.deltaTime;
    }

    public void TimeOut()
    {
        totalTime = timer;
    }

    public void AddTotalDamage(float damage)
    {
        totalGetHealth += damage;
    }

    public void ShowLevelStatistic()
    {

    }
}
