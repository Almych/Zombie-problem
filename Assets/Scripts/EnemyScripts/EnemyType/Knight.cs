using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knight : MeleeEnemy, IAttackDealer
{
    private bool isAttacking;
    private RunState runState;
    private AttackState attackState;

    public override void Die()
    {
      // will be logic soon
    }

    public override void Initiate()
    {
        moveWay = new MoveTowards(speed, rb, transform);
        runState = new RunState(transform, rb, animator, moveWay);
        attackState = new AttackState(transform, rb, animator, this);
        base.Initiate();
        stateMachine.AddState(runState);
        stateMachine.AddState(attackState);
        stateMachine.SwitchState<RunState>();
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
        if (barrier != null)
        {
            isAttacking = false;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        barrier = other.collider.GetComponent<HealthBar>();
        if (barrier != null && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(ContinuesAttack());
        }
    }

    private IEnumerator ContinuesAttack()
    {
        while (isAttacking)
        {
            if(stateMachine.currentState != attackState)
            stateMachine.SwitchState<AttackState>();
            yield return new WaitForSeconds(attackCoolDown);
        }
    }

    public void Attack()
    {
        barrier?.ChangeHealthValue(-damage);
    }
}
