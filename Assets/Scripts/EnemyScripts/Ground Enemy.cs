using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    private float health;
    private float damage;

    public GroundEnemy(float damage, float health)
    { 
        this.health = health;
        this.damage = damage;
    }
    public override void Attack (HealthBar bar)
    {
        bar.ChangeHealthValue(damage);
    }


    public override void GetDamage(float damage)
    {
        health -= damage;
    }

    public void GetAngryAbility(float speed)
    {
        speed += 1;
    }
}
