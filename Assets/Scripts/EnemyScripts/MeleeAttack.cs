using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackType
{
    protected float damage;
    public MeleeAttack(float damage) 
    {
        this.damage = damage;
    }

    public override void Attack(HealthBar healthBar)
    {
        healthBar.ChangeHealthValue(-damage);
    }
}
