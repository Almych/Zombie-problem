using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private IAttackDealer attackDealer;
    public AttackState(Transform transform, Rigidbody2D rb, Animator animator, IAttackDealer attack) : base(transform, rb, animator)
    {
        attackDealer = attack;
        SetPriority(0);
    }

    public override void Enter()
    {
        attackDealer?.Attack();
        SetTriggerAnimation("Attacking", true);
    }

    public override void Exit()
    {
        SetTriggerAnimation("Attacking", false);
    }
}
