using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/BulletItem")]
public class BulletItem : ItemObject
{
    public int amountBullet;

    public override void UseItem()
    {
       
        if (ShootController.currentMelliWeapon is MelliWeapon melli)
        {
            melli.totalBulletAmount+= amountBullet;
            melli.totalBullets=melli.totalBulletAmount;
            melli.onShootAmount.Invoke(melli.totalBullets, melli);
        }
    }

    private void Awake()
    {
        type = ItemType.Bullet;
    }
}
