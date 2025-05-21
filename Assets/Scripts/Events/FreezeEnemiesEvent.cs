using UnityEngine;

public class FreezeEnemiesEvent
{
    public int freezeDuration {  get; private set; }

    public FreezeEnemiesEvent(int durationTicks)
    {
        freezeDuration = durationTicks;
    }
}
