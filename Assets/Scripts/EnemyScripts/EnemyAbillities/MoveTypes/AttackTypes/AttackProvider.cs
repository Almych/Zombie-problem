using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackProvider : IAttackStrategy, ISpeedProvider
{
    protected Animator animator;
    protected float baseSpeed;
    internal protected int coolDownTIcks;
    public AttackProvider(Animator animator, int attackPerTicks)
    {
        this.animator = animator;
        baseSpeed = animator.speed;
        coolDownTIcks = attackPerTicks;
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
    public void ResetSpeed()
    {
        animator.speed = baseSpeed;
    }
}