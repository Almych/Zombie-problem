using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private IMovable move;

    public RunState(Transform transform, Rigidbody2D rb, Animator animator, IMovable moveWay) : base(transform, rb, animator)
    {
        move = moveWay;
        SetPriority(0);
    }

    public override void Enter()
    {
        move?.Move();
        SetTriggerAnimation("Running", true);
    }

    public override void Exit()
    {
        move?.StopMove();
        SetTriggerAnimation("Running", false);
    }
}
