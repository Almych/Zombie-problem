using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public abstract class ContinuesDamage : Damage
{
    [Range(2, 10)][SerializeField] protected float damageTime;
    [SerializeField] protected float afterMathDamage;
    protected const float remainTime = 1f;
    private Entity currentEnemy;
    private DefaultDamage defaultDamage;

    public override void MakeDamage(Entity enemy)
    {
        GetContinuesDamage(enemy);
    }

    protected virtual void GetContinuesDamage(Entity enemy)
    {
        defaultDamage = CreateInstance<DefaultDamage>();
        defaultDamage.Init(damage);
        if (enemy != null && enemy.isActiveAndEnabled)
        {
            enemy.GetDamage(defaultDamage);
        }

        currentEnemy = enemy;
        currentEnemy.StartCoroutine(TimeDamage());
    }

    private IEnumerator TimeDamage()
    {
        float remainingTime = damageTime;
        while (remainingTime > 0f)
        {
            if (currentEnemy != null && currentEnemy.isActiveAndEnabled)
                currentEnemy.GetDamage(this);
            else
                break;
            yield return new WaitForSeconds(remainTime);

            remainingTime -= remainTime;
        }
    }

    public  void StopUniqueDamage()
    {
        if (currentEnemy != null)
        {
            currentEnemy.StopCoroutine(TimeDamage());
            currentEnemy = null;
            Debug.Log("Stopped");
        }
    }
}
