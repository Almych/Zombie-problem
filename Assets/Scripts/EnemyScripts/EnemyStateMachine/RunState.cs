using UnityEngine;

public class RunState : State
{
    private MoveProvider move;
    private int currTicks;

    public RunState( Animator animator, MoveProvider moveWay) : base(animator)
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

        if (currTicks < move.coolDownTicks)
        {
            currTicks++;
        }
        else
        {
            move.moveAbility?.OnMove();
            currTicks = 0;
        }
    }
}
