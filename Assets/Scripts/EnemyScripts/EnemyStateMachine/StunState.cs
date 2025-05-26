using System;
using UnityEngine;

public class IdleState : State
{
    private int duration, currTicks;
    private Action _callbackState;

    public override PriorityType PriorityType => PriorityType.Low;

    public IdleState(Animator animator, int animationIndex, Enemy enemy, Action callbackState) : base(animator, animationIndex, enemy)
    {
      _callbackState = callbackState;
    }

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
    }


    public void ExtendDuration(int newDuration)
    {
        duration = Mathf.Max(duration, currTicks + newDuration);
    }

    public override void Exit()
    {
        currTicks = 0;
    }
    public override void Freeze(int duration)
    {
        base.Freeze(duration); 
    }

    public override void OnTick()
    {
        currTicks++;
        if(currTicks >= duration)
        {
            _callbackState();
            currTicks = 0;
        }
    }

    public void SetDuration(int duration)
    {
        if(this.duration > 0)
            ExtendDuration(duration);
        else
        this.duration = duration;
    }
}
