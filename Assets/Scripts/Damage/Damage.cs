using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class Damage : ScriptableObject
{
    [SerializeField] protected float damage;
    public abstract void MakeDamage(Entity enemy);
}
