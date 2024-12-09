using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melli weapon", menuName = "Weapons/Melli")]
public class MelliWeapon : Weapon
{
    public Action<int, MelliWeapon> onShootAmount;

    public float reloadTime;
    public int maxBullets;
    public Sprite bulletSprite;
    public int totalBulletAmount;
    public int totalBullets;
    public int TotalAmount
    {
        get => totalBullets;

         set
        {
            onShootAmount?.Invoke(totalBullets, this);
           
        }
    }

    private void OnEnable()
    {
        totalBullets = totalBulletAmount;
    }
}
