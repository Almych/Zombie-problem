using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public float damage;
    public Sprite weaponIcon;
    internal protected event Action WeaponDebaf;
}


