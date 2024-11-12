using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades/EffectGranade")]
public class EffectGranade : Granade, IItemEffectable
{
    public float effectTime;

    public void Effect()
    {
        Debug.Log("Froze");
    }

    public override void Throw()
    {
        Effect();
    }
}
