using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New EffectGrenade", menuName = "ItemMenu/Items/Grenades/EffectGrenade")]
public class EffectGrenade : Grenade
{
    [SerializeField] private float effectTime;

    public override void Use()
    {
        Debug.Log("Effect used");
    }
}
