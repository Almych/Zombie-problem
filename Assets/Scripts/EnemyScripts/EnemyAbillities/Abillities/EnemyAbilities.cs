using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class OnDamageEnemyAbility
{
    protected Transform transform;
    protected Rigidbody2D rb;
    //protected OnDamageEnemyAbility(Entity enemy) 
    //{
    //    transform = enemy.transform;
    //    rb = enemy.rb;
    //}

    public abstract void OnDamage();
}

public abstract class OnDeathEnemyAbility
{
    protected Transform transform;
    protected Rigidbody2D rb;
    //protected OnDeathEnemyAbility(Entity enemy)
    //{
    //    transform = enemy.transform;
    //    rb = enemy.rb;
    //}

    public abstract void OnDeath();
}




