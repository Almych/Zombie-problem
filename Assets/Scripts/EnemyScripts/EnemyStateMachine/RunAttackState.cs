using UnityEngine;

public class RunAttackState : IState
{
    private AttackState _attackState;
    private RunState _runState;
    private int changeStateTime, currTime;
    private State currentState;
    private bool isAttacking;
    private Enemy _enemy;
    public RunAttackState(RunState runState, AttackState attackState, int switchTimeTicks, Enemy enemy)
    {
        _attackState = attackState;
        _runState = runState;
        changeStateTime = switchTimeTicks;
        _enemy = enemy;
    }

    public PriorityType PriorityType => PriorityType.Low;

    public void Enter()
    {
        currentState = _runState;
        currentState.Enter();
        currTime = 0;
        isAttacking = false;
    }

    public void Exit()
    {
        currentState.Exit();
    }
    public bool isFroze()
    {
        return currentState.isFroze();
    }
    public void Tick()
    {
        if(!currentState.isFroze()) 
        currTime++;

        if (!isAttacking && currTime >= changeStateTime)
        {
            ChangeState(_attackState);
            _enemy.CallAttackAbility();
            isAttacking = true;
            currTime = 0;
        }
        else if (isAttacking && currTime >= _enemy.attackDealer.coolDownTIcks) 
        {
            ChangeState(_runState);
            _enemy.CallMoveAbility();
            isAttacking = false;
            currTime = 0;
        }

        currentState.Tick();
    }

    public virtual void Freeze(int duration)
    {
       currentState?.Freeze(duration);
    }


    private void ChangeState(State newState)
    {
        if (currentState == newState) return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
