using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/BulletItem")]
public class BulletItem : ItemObject
{
    public int amountBullet;

    protected override void ItemAbillity()
    {
        if (ShootController.controller.weapon is MelliWeapon melli)
        {
            melli.totalBullets += amountBullet;
            melli.totalBulletAmount += amountBullet;
        }
    }


    private void Awake()
    {
        type = ItemType.Bullet;
    }
}
