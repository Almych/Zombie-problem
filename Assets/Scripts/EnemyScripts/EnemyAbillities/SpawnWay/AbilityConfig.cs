using System;
using UnityEngine;

public abstract class AbilityConfig : ScriptableObject 
{
    //public void GetAbilities(Action onDeath, Action onMove, Action onAttack, Action onGetDamage)
    //{

    //}

    public abstract Action ApplyAbilities(Enemy enemy);
}
