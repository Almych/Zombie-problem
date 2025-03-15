using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseEvent 
{
    public bool IsPaused { get; private set; }
    public OnPauseEvent(bool isPaused)
    {
        IsPaused = isPaused;
    }
}
