
using UnityEngine;

public abstract class Damage : ScriptableObject, IDamageStrategy
{
    [SerializeField] protected float damage;

    public float GetDamage()
    {
        return damage;
    }

    public abstract void MakeDamage(Entity enemy);
}



