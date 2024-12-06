using System;
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
    public int amount;
    public Sprite prefab;
    [TextArea(15, 20)]public string description;
    public event Action<int, ItemObject> OnItemUse;

    protected abstract void ItemAbillity();
    public void UseItem()
    {
        if (amount > 0)
        {
            amount--;
            ItemAbillity();
            OnItemUse?.Invoke(amount, this);
        }
    }
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