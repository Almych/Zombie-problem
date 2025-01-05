using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crit Damage", menuName = "Damage/Froze Damage")]
public class FrozeDamage : Damage
{
    [Range(1, 5)] private float frozeTime;
    private const float frozeChance = 7;

    public override void MakeDamage(Entity enemy)
    {
        enemy.GetDamage(damage);
        float toFroze = UnityEngine.Random.Range(1, 10);
        if (enemy.isActiveAndEnabled && toFroze >= frozeChance)
        {
            Debug.Log("Freze");
        }
    }
}