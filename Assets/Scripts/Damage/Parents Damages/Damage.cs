
using UnityEngine;

public abstract class Damage : ScriptableObject, IDamageStrategy
{
     [SerializeField] protected float _damage;

    

    public abstract DamageType damageType { get;}

    public float GetDamage()
    {
        return _damage;
    }

    public abstract void MakeDamage(Enemy enemy);
}



