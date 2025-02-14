using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour, ICollectable
{
    public void OnCollect()
    {
        View.Instance.AddCoin();
       gameObject.SetActive(false);
    }
}
