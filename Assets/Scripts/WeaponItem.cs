using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    [SerializeField] protected Weapon weapon;

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
