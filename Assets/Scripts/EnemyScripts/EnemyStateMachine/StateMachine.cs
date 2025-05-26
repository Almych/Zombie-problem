using System;
using UnityEngine;
public enum StunType
{
    Froze,
    Stun
}

public class StateMachine
{
    public IState currentState { get; private set; }
    public IState lastState { get; private set; }
    private IdleState _idleState;
    private RunState _runState;
    private AttackState _attackState;
    private DieState _dieState;

    public StateMachine(IdleState idleState,RunState runState, AttackState attackState, DieState dieState)
    {
        _runState = runState;
        _attackState = attackState;
        _dieState = dieState;
        _idleState = idleState;
        currentState = idleState;
    }

    public void StopState(int duration, StunType stunType = StunType.Stun)
    {
        if(stunType == StunType.Stun && !currentState.isFroze())
        {
            _idleState.SetDuration(duration);
            SwitchState(_idleState);
        }
        else if (stunType == StunType.Froze)
        {
            currentState.Freeze(duration);
        }

    }


    public void SwitchState(IState newState, bool force = false)
    {
        if (currentState is IdleState && newState is IdleState) return;
        if (!force && currentState.PriorityType > newState.PriorityType)
        {
            return;
        }
        lastState = currentState;
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

   
    public void OnTick()
    {
        currentState?.Tick();
    }
}
