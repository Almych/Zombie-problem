using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private IEnemy _attackDealer;
    public AttackState(Animator animator, IEnemy attackDealer) : base(animator)
    {
        _attackDealer = attackDealer;
    }

    public override void Enter()
    {
       SetTriggerAnimation(attackAnimation);
    }

    public override void Exit()
    {
       
    }

    public override void Tick()
    {
       // _attackDealer.Attack();
    }
}
