using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private IEnemy _enemy;
    public DieState(Transform transform, Rigidbody2D rb, Animator animator, IEnemy enemy) : base(transform, rb, animator)
    {
       _enemy = enemy;
    }

    public override void Enter()
    {
        SetTriggerAnimation("Die", true);
                                                             
    }

    public override void Exit()
    {
        SetTriggerAnimation("Die", false);
    }
}
