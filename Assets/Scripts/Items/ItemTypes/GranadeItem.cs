using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades")]
public abstract class GranadeItem : ItemObject
{
    public float throwDistance;
    public float radius;

    private void Awake()
    {
        type = ItemType.Granade;
    }
}
