using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private IEnemy _enemy;
    public AttackState(Transform transform, Rigidbody2D rb, Animator animator, IEnemy enemy) : base(transform, rb, animator)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        _enemy.Attack();
        SetTriggerAnimation("Attacking", true);
    }

    public override void Exit()
    {
        SetTriggerAnimation("Attacking", false);
    }
}
