using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Entity
{
    [SerializeField] protected float attackCoolDown;
    protected HealthBar barrier;
    protected abstract void OnColliderTrigger2D(Collider2D other);
}
