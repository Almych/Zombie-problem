using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieEvent
{
    public PlayerDieEvent()
    {
        EventBus.Publish(new OnPauseEvent(true));
    }
}
