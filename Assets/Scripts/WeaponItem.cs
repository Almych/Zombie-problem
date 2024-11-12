using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ItemObject
{
    [SerializeField] protected Weapon weapon;
    private void Awake()
    {
        if (weapon is MelliGun melli)
        {
            
        }
        type = ItemType.Weapon;
    }
}
