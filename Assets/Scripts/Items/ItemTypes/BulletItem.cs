using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/BulletItem")]
public class BulletItem : ItemObject
{
    public int amountBullet;
    public Weapon weaponType;


    private void Awake()
    {
        type = ItemType.Bullet;
    }
}
