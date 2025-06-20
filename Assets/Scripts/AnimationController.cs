using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController
{
    private Dictionary<Ability, AbilityEvents> abilities = new Dictionary<Ability, AbilityEvents>();
    public void AddAbility(Ability ability, AbilityEvents abilityEvents)
    {
        abilities[ability] = abilityEvents;
    }

}

public class AbilityEvents
{
    private Action onDeath, onMove, onAttack, onDetect, onDamage;
    public AbilityEvents(Action onDeath = null, Action onMove = null, Action onAttack = null, Action onDetect = null, Action onDamage = null)
    {
        this.onDeath = onDeath;
        this.onMove = onMove;
        this.onAttack = onAttack;
        this.onDetect = onDetect;
        this.onDamage = onDamage;
    }

    public void CallMoveAbility() => onMove?.Invoke();
    public void CallDetectAbility() => onDetect?.Invoke();
    public void CallDeathAbility() => onDeath?.Invoke();
    public void CallAttackAbility() => onAttack?.Invoke();
    public void CallDamageAbility() => onDamage?.Invoke();
}

