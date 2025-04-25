using UnityEngine;

public abstract class AttackTypeConfig : ScriptableObject
{
    [SerializeField] protected int coolDown;
    protected AttackProvider attackProvider;

    public virtual AttackProvider SetAttack(Enemy enemy)
    {
        return attackProvider;
    }
}
