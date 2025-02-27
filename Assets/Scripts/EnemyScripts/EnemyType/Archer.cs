using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : RangedEnemy, IAttackDealer
{
    private AttackState attackState;

    public void Attack()
    {
       EnemyBulletBehaivior bullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (bullet != null )
        {
            bullet.transform.position = transform.position;
            bullet.Activate(damage, bulletSprite, bulletSpeed);
        }
    }

    public override void Die()
    {
       base.Die();
    }

    public override void Initiate()
    {
        base.Initiate();
        StartCoroutine(DetectEnemy());
    }

    public override void Init()
    {
        moveWay = new MoveTowards(new MoveStats{_transform = transform, _rb = rb, _speed = speed});
        attackState = new AttackState(transform, rb, animator, this);
        base.Init();
        stateMachine.AddState(runState);
        stateMachine.AddState(attackState);
    }

    protected override IEnumerator DetectEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(detectTime);
            hit = Physics2D.Raycast(transform.position, Vector2.left, attackDistance, triggerMask);
            if (hit.collider != null)
            {
                moveWay.StopMove();
                stateMachine.SwitchState<AttackState>();
            }
        }
    }
}
