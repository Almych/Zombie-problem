using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public StunedState stunedState;
    public RunState runState;
    public AttackState attackState;
    public DeadState deadState;
    public State currentState { get; private set; }
    public StateMachine(Entity entity)
    {
        runState = new RunState(entity.animator, entity.rb, entity.transform, entity.enemyData.speed);
        attackState = new AttackState(entity.animator, entity.rb, entity.transform, entity.Attack);
        stunedState = new StunedState(entity.animator, entity.rb, entity.transform);
        deadState = new DeadState(entity.animator, entity.rb, entity.transform);
        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
