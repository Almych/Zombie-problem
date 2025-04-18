using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBinder
{
    public Action onDeath, onMove, onAttack, onGetDamage;
    
    public void BindDeath(IDeathAbility deathAbility)
    {
        onDeath += deathAbility.OnDeath;
    }

    public void BindMove(IMoveAbility moveAbility)
    {
        onDeath += moveAbility.OnMove;
    }

    public void BindAttack(IAttackAbility attackAbility)
    {
        onDeath += attackAbility.OnAttack;
    }

    public void BindDamage(IDamageAbility damageAbility)
    {
        onDeath += damageAbility.OnGetDamage;
    }

    public void UnbindAll()
    {
        onDeath = null;
        onMove = null;
        onAttack = null;
        onGetDamage = null;
    }
}
