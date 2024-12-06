using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ItemObject
{
    [SerializeField] protected Weapon weapon;

    protected override void ItemAbillity()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        if (weapon is MelliWeapon melli)
        {
            type = ItemType.Weapon;
        }
    }
}
