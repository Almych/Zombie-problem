using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MeleeEnemy
{
    private RunState runState;
    private StunState stunState;
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
       
    }

    public override void Initiate()
    {
        moveWay = new MoveTowards(speed, rb, transform);
        stunState = new StunState(transform, rb, animator);
        runState = new RunState(transform, rb, animator, moveWay);
        base.Initiate();
        stateMachine.AddState(runState);
        stateMachine.AddState(stunState);
        stateMachine.SwitchState<RunState>();
    }
}
