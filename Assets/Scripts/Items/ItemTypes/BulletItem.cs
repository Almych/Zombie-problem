using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/BulletItem")]
public abstract class Bullets : Item
{
    public readonly Damage damage;
}
