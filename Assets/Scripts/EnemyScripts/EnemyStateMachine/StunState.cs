using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    public StunState(Transform transform, Rigidbody2D rb, Animator animator) : base(transform, rb, animator)
    {

    }

    public override void Enter()
    {
        SetTriggerAnimation("Stunned", true);
    }

    public override void Exit()
    {
        SetTriggerAnimation("Stunned", false);
    }
}
