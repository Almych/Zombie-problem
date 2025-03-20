using UnityEngine;

public class DieState : State
{
    public DieState(Animator animator) : base(animator)
    {
    }

    public override void Enter()
    {
        SetTriggerAnimation(dieAnimation);
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
        
    }
}
