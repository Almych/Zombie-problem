using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bullets", menuName = "ItemMenu/Items/BulletItem")]
public class Bullets : Item
{
    public readonly Damage damage;

    public override void Use()
    {
        if (ShootController.controller.weapon is MelliWeapon melli)
        {
            melli.totalBulletAmount += melli.maxBullets;
            melli.totalBullets += melli.maxBullets;
        }
    }
}
