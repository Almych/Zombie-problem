using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Coins Container", menuName = "CoinsContainer")]
public class CoinsContainer : ScriptableObject
{
    [SerializeField] private int coinsAmount;


    public void AddCoin()
    {
        coinsAmount++;
    }

    public int GetCoins()
    {
        return coinsAmount;
    }
}
