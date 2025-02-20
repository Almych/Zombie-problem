using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : RangedEnemy, IAttackDealer
{
    private RunState runState;
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
       
    }

    public override void Initiate()
    {
        moveWay = new ZigZagMove(transform, rb, speed);
        runState = new RunState(transform, rb, animator, moveWay);
        attackState = new AttackState(transform, rb, animator, this);
        base.Initiate();
        stateMachine.AddState(runState);
        stateMachine.AddState(attackState);
        stateMachine.SwitchState<RunState>();
        StartCoroutine(DetectEnemy());
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
