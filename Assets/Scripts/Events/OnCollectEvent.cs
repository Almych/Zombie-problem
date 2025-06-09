using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollectEvent 
{
    public object collectable { get; private set; }
    public OnCollectEvent(object collectable)
    {
       this.collectable = collectable;
    }
}
