
using UnityEngine;

public abstract class Damage : IDamageStrategy
{
     protected float _damage;

    protected Damage(float damage)
    {
        _damage = damage;
    }
    public float GetDamage()
    {
        return _damage;
    }

    public abstract void MakeDamage(Entity enemy);
}



