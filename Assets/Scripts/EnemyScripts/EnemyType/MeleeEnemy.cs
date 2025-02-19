using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Entity
{
    [SerializeField] protected float attackCoolDown;
    protected  HealthBar barrier;
    protected abstract void OnCollisionEnter2D(Collision2D other);
    protected abstract void OnCollisionExit2D(Collision2D other);
}
