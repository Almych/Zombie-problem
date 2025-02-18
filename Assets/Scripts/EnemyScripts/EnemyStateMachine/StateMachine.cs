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
    public StateMachine(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator, Collider2D collider)
    {
        runState = new RunState(transform, rb, enemyConfig, animator);
        attackState = new AttackState(transform, rb, enemyConfig, animator);
        stunedState = new StunnedState(transform, rb, enemyConfig, animator);
        deadState = new DeadState(transform, rb, enemyConfig, animator, collider);
        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
