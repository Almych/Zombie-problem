using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melli weapon", menuName = "Weapons/Melli")]
public class MelliWeapon : Weapon
{
    public Action<float, MelliWeapon> onShootAmount;

    public float reloadTime;
    public int maxBullets;
    public Sprite bulletSprite;
    public int totalBulletAmount;
    internal protected int totalBullets;
    public int TotalAmount
    {
        get => totalBullets;

         set
        {
            onShootAmount?.Invoke(totalBullets, this);
            Debug.Log("called");
        }
    }

    private void OnEnable()
    {
        if (totalBulletAmount <= 0)
            totalBulletAmount = maxBullets * 2;

        totalBullets = totalBulletAmount;
    }
}
