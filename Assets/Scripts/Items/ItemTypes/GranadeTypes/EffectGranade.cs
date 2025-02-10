using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades/EffectGranade")]
public abstract class EffectGrenade : Grenade
{
    [SerializeField] private float effectTime;
}
