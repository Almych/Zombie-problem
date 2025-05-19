using UnityEngine;

public abstract class WeaponConfig : ScriptableObject, IWeaponConfig
{
    public abstract Damage damage { get; set; }
    public abstract Sprite weaponSprite { get; set; }
}


