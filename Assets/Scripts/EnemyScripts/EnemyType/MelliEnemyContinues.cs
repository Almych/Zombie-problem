using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IMelliEnemy
{
    public void OnCollisionEnter2D(Collision2D collision);
}
public class MelliEnemyContinues : MelliEnemyNone
{
    public override void Initiate()
    {
       rb.velocity = -transform.right * enemyData.speed;
    }

    private void OnEnable()
    {
        OnDamage += enemyAbility.UniqAbillityUse;
    }

    private void OnDisable()
    {
        OnDamage -= enemyAbility.UniqAbillityUse;
    }

    public override void AbilityAdd()
    {
        enemyAbility = new DiagnolMoveAbility(transform, rb, enemyData.speed, this);
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            var barrier = collision.collider.GetComponent<HealthBar>();
            isAttacking = true;
            StartCoroutine(ContinuesAttack(barrier));
        }
    }
                                                
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            isAttacking = false;
        }
    }

    protected IEnumerator ContinuesAttack(HealthBar barrier)
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(enemyData.attackCoolDown);
            Attack(barrier);
        }
    }
}
