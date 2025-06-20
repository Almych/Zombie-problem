using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : Takable
{
    private int countAmount;
    public override void OnCollect()
    {
        Debug.Log(countAmount);
       EventBus.Publish(new OnCollectEvent(countAmount));
        base.OnCollect();
    }

    public void SetCollectable(int countAmount)
    {
        this.countAmount = countAmount;
    }
    
}
