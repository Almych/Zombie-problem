using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "New StunEffect Damage", menuName = "Damage/StunEffect Damage")]
public class StunEffectDamage : Damage
{
    [SerializeField] private float stunTime;
    [Range(1, 7)][SerializeField] private float effectChange;
    private DefaultDamage defaultDamage;
    public override void MakeDamage(Entity enemy)
    {
        enemy.StartCoroutine(StunEnemy(enemy));
    }
    
    private IEnumerator StunEnemy(Entity enemy)
    {
        enemy.GetDamage(damage, defaultDamage);
        float toStun = UnityEngine.Random.Range(1, 10);
        if (enemy.isActiveAndEnabled && toStun >= effectChange)
        {
            enemy.StopMove();
            yield return new WaitForSeconds(stunTime);
            enemy.Initiate();
        }
    }
}
