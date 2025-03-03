using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour, ICollectable
{
    public void OnCollect()
    {
       EventBus.Publish(new OnCollectEvent());
       gameObject.SetActive(false); 
    }
}
