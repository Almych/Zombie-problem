using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Damage", menuName = "Damage/Default Damage")]
public class DefaultDamage : Damage
{
    public override void MakeDamage(Entity enemy)
    {
        enemy.GetDamage(damage, this);
    }
}
