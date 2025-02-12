using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(fileName = "New DamageGrenade", menuName = "ItemMenu/Items/Grenades/DamageGrenade")]
public class DamageGrenade : Grenade
{
    [SerializeField] protected Damage damageType;

    public override void Use()
    {
        Debug.Log("Damage to enemies");
    }
}

