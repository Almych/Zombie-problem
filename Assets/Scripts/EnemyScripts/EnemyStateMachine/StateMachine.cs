using System;
using System.Collections.Generic;

public class StateMachine
{
    public State currentState { get; private set; }
    private Dictionary<Type, State> stateMap = new();

    public StateMachine(RunState runState, AttackState attackState, DieState dieState)
    {
        stateMap[typeof(RunState)] = runState;
        stateMap[typeof(AttackState)] = attackState;
        stateMap[typeof(DieState)] = dieState;

        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void TryTranslate<T>() where T : State
    {
        if (stateMap[typeof(T)] != null)
        {
            SwitchState(stateMap[typeof(T)]);
        }
    }

    public void OnTick()
    {
        currentState?.Tick();
    }
}
