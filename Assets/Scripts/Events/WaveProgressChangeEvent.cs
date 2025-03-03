using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProgressChangeEvent 
{
    public float value;
    public WaveProgressChangeEvent(float progress)
    {
        value = progress;
    }
}
