using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melli weapon", menuName = "Weapons/Melli")]
public class MelliGun : Weapon
{
    public float reloadTime;
    public int maxBullets;
    public Sprite bulletSprite;
    public int totalBulletAmount;
    private void OnEnable()
    {
        if (totalBulletAmount <= 0)
        totalBulletAmount = maxBullets * 2;
    }
}
