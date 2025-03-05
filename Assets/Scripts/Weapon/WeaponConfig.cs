using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponConfig
{
     Damage damage { get; set; }
     Sprite weaponSprite { get; set; }
}

public abstract class WeaponConfig : ScriptableObject, IWeaponConfig
{
    public abstract Damage damage { get; set; }
    public abstract Sprite weaponSprite { get; set; }
}


