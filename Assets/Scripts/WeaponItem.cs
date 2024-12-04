using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ItemObject
{
    [SerializeField] protected Weapon weapon;

    public override void UseItem()
    {
        
    }

    private void Awake()
    {
        if (weapon is MelliWeapon melli)
        {
            type = ItemType.Weapon;
        }
    }
}
