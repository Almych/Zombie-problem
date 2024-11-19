using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melli weapon", menuName = "Weapons/Melli")]
public class MelliWeapon : Weapon
{
    public Func<int, int> onShootAmount;
    public int TotalBullets
    {
        get => totalBulletUi;
      

        set
        {
            Debug.Log("Called bullet dicrement");
            onShootAmount?.Invoke(totalBulletUi);
        }
    }

    public float reloadTime;
    public int maxBullets;
    public Sprite bulletSprite;
    public int totalBulletAmount;
    public int totalBulletUi;
    private void OnEnable()
    {
        if (totalBulletAmount <= 0)
        totalBulletAmount = maxBullets * 2;
    }
}
