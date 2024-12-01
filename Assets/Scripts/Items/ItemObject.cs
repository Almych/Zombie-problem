using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Aim,
    Granade,
    Bullet,
    Weapon
}
public abstract class ItemObject : ScriptableObject
{
    public ItemType type;
    public Sprite prefab;
    [TextArea(15, 20)]public string description;


}


public interface IItemHealable
{
    public float Heal();
}

public interface IItemDamagable
{
    public void MakeDamage();
}

public interface IItemThrowable
{
    public void Throw ();
}

public interface IItemRestorable
{

}

public interface IItemEffectable
{
    public void Effect();
}