using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public StunnedState stunedState;
    public RunState runState;
    public AttackState attackState;
    public DeadState deadState;
    public State currentState { get; private set; }
    public StateMachine(Entity entity)
    {
        runState = new RunState(entity);
        attackState = new AttackState(entity);
        stunedState = new StunnedState(entity);
        deadState = new DeadState(entity);
        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
