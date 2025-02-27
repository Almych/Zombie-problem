using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Damage", menuName = "Damage/Default Damage")]
public class DefaultDamage : Damage
{
    private float _damage;
    public void Init(float damage)
    {
         _damage = damage;
    }

    public override void MakeDamage(Entity enemy)
    {
        enemy.TakeDamage(this);
    }
}
