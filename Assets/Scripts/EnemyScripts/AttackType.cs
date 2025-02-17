using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackType : IAttackStrategy
{
    protected AttackType()
    {
        
    }
    public abstract void Attack(HealthBar healthBar);
}
