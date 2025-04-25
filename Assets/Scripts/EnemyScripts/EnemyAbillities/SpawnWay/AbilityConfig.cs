using System;
using UnityEngine;

public abstract class AbilityConfig : ScriptableObject 
{
    [SerializeField] protected int callPerTicks;
    [SerializeField] protected bool callOnce;
    protected Ability resultAbility;
    //public void GetAbilities(Action onDeath, Action onMove, Action onAttack, Action onGetDamage)
    //{

    //}

    public virtual Action ApplyAbilities(Enemy enemy)
    {
        return resultAbility.InvokeAbility;
    }
}

