using UnityEngine;

public class DefaultDamage : Damage
{
    public DefaultDamage(float damage) : base(damage)
    {
    }

    public override void MakeDamage(Entity enemy)
    {
        enemy.TakeDamage(this);
    }
}
