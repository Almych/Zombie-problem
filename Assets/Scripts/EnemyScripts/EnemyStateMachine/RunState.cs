using UnityEngine;

public class RunState : State
{
    private IMovable move;

    public RunState( Animator animator, IMovable moveWay) : base(animator)
    {
        move = moveWay;
    }
    public override void Enter()
    {
        SetTriggerAnimation(runAnimation);
    }

    public override void Exit()
    {
        move?.StopMove();
    }

    public override void Tick()
    {
        move.Move();
    }
}
