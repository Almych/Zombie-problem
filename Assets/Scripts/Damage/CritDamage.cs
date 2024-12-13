using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Crit Damage", menuName = "Damage/Crit Damage")]
public class CritDamage : Damage
{

    [Range(1, 5)][SerializeField] private float critChange;


    public override void MakeDamage(Action<float> DoEnemyDamage, Entity enemy)
    {
        float critDamage = UnityEngine.Random.Range(1, 10);
        if (critDamage >= critChange)
        {
            DoEnemyDamage(damage * 2);
        }
        else
        {
            DoEnemyDamage(damage);
        }
    }
}

