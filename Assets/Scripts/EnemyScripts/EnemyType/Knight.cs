using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knight : MeleeEnemy, IAttackDealer
{
    private bool isAttacking;
    private AttackState attackState;

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
            stateMachine.SwitchState<AttackState>();
            yield return new WaitForSeconds(attackCoolDown);
        }
    }

    public void Attack()
    {
        barrier?.ChangeHealthValue(-damage);
    }

    public override void Init()
    {
        moveWay = new MoveTowards(new MoveStats { _transform = transform, _rb = rb, _speed = speed });
        attackState = new AttackState(transform, rb, animator, this);
        base.Init();
        stateMachine.AddState(runState);
        stateMachine.AddState(attackState);
    }
}
