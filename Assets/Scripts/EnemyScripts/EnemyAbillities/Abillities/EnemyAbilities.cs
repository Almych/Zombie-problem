using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class OnDamageEnemyAbillity
{
    protected Transform transform;
    protected Rigidbody2D rb;
    protected OnDamageEnemyAbillity(Entity enemy) 
    {
        transform = enemy.transform;
        rb = enemy.rb;
    }

    public abstract void OnDamage();
}

public abstract class OnDeathEnemyAbillity
{
    protected Transform transform;
    protected Rigidbody2D rb;
    protected OnDeathEnemyAbillity(Entity enemy)
    {
        transform = enemy.transform;
        rb = enemy.rb;
    }

    public abstract void OnDeath();
}




