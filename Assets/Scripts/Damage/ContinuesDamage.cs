using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Continues Damage", menuName = "Damage/Continues Damage")]
public class ContinuesDamage : Damage
{
    [SerializeField] private float damageTime;
    [SerializeField] private float afterMathDamage;
    private const float remainTime = 1f;
    private DefaultDamage defaultDamage;
    public override void MakeDamage(Entity enemy)
    {
        enemy.StartCoroutine(GetContinuesDamage(enemy));
    }

    private IEnumerator GetContinuesDamage(Entity enemy)
    {
        float bleedTime = damageTime;
        enemy.GetDamage(damage, defaultDamage);
        while (bleedTime > 0f)
        {
            if (enemy.isActiveAndEnabled)
                enemy.GetDamage(afterMathDamage, this);
            yield return new WaitForSeconds(remainTime);
            bleedTime -= 0.5f;
        }
    }

}
