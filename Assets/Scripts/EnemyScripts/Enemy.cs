using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy 
{ 
    public enum EnemyType
    {
        Grounder,
        Flyer,
        LongRange
    };
    public abstract void Attack(HealthBar bar);
    public abstract void GetDamage(float damage);
}
