using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades/EffectGranade")]
public class EffectGranade : Granade
{
    [SerializeField] private float effectTime;

    private void Effect()
    {
        Debug.Log("Froze");
    }

    public override void Throw()
    {
        Effect();
    }
}
