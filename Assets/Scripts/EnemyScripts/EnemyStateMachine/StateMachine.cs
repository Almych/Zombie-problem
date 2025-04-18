using System;
using System.Collections.Generic;

public class StateMachine
{
    private State currentState;
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
        if (stateMap.TryGetValue(typeof(T), out State targetState))
        {
            SwitchState(targetState);
        }
    }

    public void OnTick()
    {
        currentState?.Tick();
    }
}
