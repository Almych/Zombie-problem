using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdWeapon : Weapon
{
    [Range(0.3f, 0.6f)]
    [SerializeField] protected float hitTime;
    protected void Hit()
    {

    }
}
