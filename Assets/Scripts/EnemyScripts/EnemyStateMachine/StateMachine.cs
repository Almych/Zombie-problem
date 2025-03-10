using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine 
{
    public State currentState {  get; private set; }
    private RunState runState;
    private AttackState attackState;
    private DieState dieState;
    public StateMachine(RunState runState, AttackState attackState, DieState dieState)
    {
        this.runState = runState;
        this.attackState = attackState;
        this.dieState = dieState;
        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
    
    public void OnTick()
    {
        currentState?.Tick();
    }
}
