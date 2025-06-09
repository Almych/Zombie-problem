using UnityEngine;

public class OnLevelUnlockEvent
{
    public int levelReached {  get; private set; }
    public OnLevelUnlockEvent(int levelReached)
    {
        this.levelReached = levelReached;
    }
}
