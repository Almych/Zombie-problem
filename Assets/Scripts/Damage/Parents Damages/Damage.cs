using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class Damage : ScriptableObject, IDamage
{
    [SerializeField] protected float damage;
    public abstract void MakeDamage(Entity enemy);

    internal protected Damage GetDamage()
    {
        return this;
    }
}


public interface IDamage
{
    public void MakeDamage(Entity enemy);
}

