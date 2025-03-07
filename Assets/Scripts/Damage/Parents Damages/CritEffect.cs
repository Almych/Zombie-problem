using UnityEngine;

public class CritEffect : Damage
{
    private float _critChance;
    private float _maxCritChance = 10f;
    public CritEffect(float damage, float critChance = 1f) : base(damage)
    {
        _critChance = critChance;
    }

    public override void MakeDamage(Entity enemy)
    {
        if (Random.value <= _critChance) 
        {
            enemy.TakeDamage(this);
        }

        enemy.TakeDamage(this);
    }
}
