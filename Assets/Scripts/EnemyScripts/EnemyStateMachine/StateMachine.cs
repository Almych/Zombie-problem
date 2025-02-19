using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public State currentState {  get; private set; }
    public RunState runState { get; private set; }
    public DieState dieState { get; private set; }
    public StunState stunState { get; private set; }
    public AttackState attackState  { get; private set; }

    public StateMachine(Transform transform, Rigidbody2D rb, Animator animator, IMovable movable, IEnemy enemy)
    {
        runState = new RunState(transform, rb, animator, movable);
        dieState = new DieState(transform, rb, animator, enemy);
        stunState = new StunState(transform, rb, animator);
        attackState = new AttackState(transform, rb, animator, enemy);
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
