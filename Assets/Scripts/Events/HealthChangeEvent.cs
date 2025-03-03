using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeEvent 
{
    public float value { get; private set; }
    public HealthChangeEvent(float value)
    {
        this.value = value;
    }
}
