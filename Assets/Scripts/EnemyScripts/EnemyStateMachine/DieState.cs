using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private Entity _enemy;
    public DieState(Transform transform, Rigidbody2D rb, Animator animator, Entity enemy) : base(transform, rb, animator)
    {
        SetPriority(3);
        _enemy = enemy;
    }

    public override void Enter()
    {
        SetTriggerAnimation("Die");
    }

    public override void Exit()
    {
    }

}
