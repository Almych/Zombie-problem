using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public abstract class ContinuesDamage: Damage
{
    [Range(2, 10)][SerializeField] protected float damageTime;
    [SerializeField] protected float afterMathDamage;
    protected const float remainTime = 1f;
    public override void MakeDamage(Entity enemy)
    {
        enemy.StartCoroutine(GetContinuesDamage(enemy));
    }

    protected virtual IEnumerator GetContinuesDamage(Entity enemy)
    {
        float remainingTime = damageTime;

        if (enemy != null && enemy.isActiveAndEnabled)
        {
            enemy.GetDamage(damage, default);
        }

        while (remainingTime > 0f)
        {
            if (enemy != null && enemy.isActiveAndEnabled)
                enemy.GetDamage(afterMathDamage, GetDamage());
            else
                break;
            yield return new WaitForSeconds(remainTime);

            remainingTime -= remainTime;
        }
    }

}
