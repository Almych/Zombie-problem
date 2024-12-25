using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class OnDamageEnemyAbillity : EnemyAbillity
{
    protected OnDamageEnemyAbillity(Transform unit, Rigidbody2D unitRb) : base(unit, unitRb)
    {
    }

    public abstract void OnDamage();
}

public abstract class OnDeathEnemyAbillity : EnemyAbillity
{
    protected OnDeathEnemyAbillity(Transform unit, Rigidbody2D unitRb) : base(unit, unitRb)
    {
    }

    public abstract void OnDeath();
}
public abstract class EnemyAbillity
{
    protected Transform _unit;
    protected Rigidbody2D _unitRb;
    protected EnemyAbillity(Transform unit, Rigidbody2D unitRb)
    {
        _unit = unit;
        _unitRb = unitRb;
    }
}




