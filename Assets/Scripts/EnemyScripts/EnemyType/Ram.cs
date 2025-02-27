using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MeleeEnemy
{
    private StunState stunState;
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        HealthBar barrier = other.collider.GetComponent<HealthBar>();
        if (barrier != null)
            stateMachine.SwitchState<DieState>();
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
       
    }
    public override void Die()
    {
        base.Die();
    }
    public override void Initiate()
    {
        base.Initiate();
    }

    public override void Init()
    {
        moveWay = new MoveTowards(new MoveStats { _transform = transform, _rb = rb, _speed = speed });
        stunState = new StunState(transform, rb, animator);
        runState = new RunState(transform, rb, animator, moveWay);
        base.Init();
        stateMachine.AddState(runState);
        stateMachine.AddState(stunState);
    }
}
