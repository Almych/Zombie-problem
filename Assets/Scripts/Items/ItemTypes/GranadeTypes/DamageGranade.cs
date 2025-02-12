using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DamageGrenade : Grenade
{
    [SerializeField] protected Damage damageType;
}

