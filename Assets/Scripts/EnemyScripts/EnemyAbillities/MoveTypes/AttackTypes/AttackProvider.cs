using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackProvider : IAttackStrategy, ISpeedProvider
{
    Animator animator;
    private float baseSpeed;
    public AttackProvider(Animator animator)
    {
        this.animator = animator;
        baseSpeed = animator.speed;
    }

    public abstract void ExecuteAttack(HealthBar healthBar = null);

    public void IncreaseSpeed(float speedProcents = 0.1F)
    {
        animator.speed = baseSpeed / speedProcents;
    }

    public void ReduceSpeed(float speedProcents = 0.1F)
    {
        animator.speed = baseSpeed * speedProcents;
    }
}