using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamageDecorator : Damage, IDamageEffect
{
    [SerializeField] protected DefaultDamage defaultDamage;
    

    public abstract void ApplyEffect(Enemy enemy);

   
}
