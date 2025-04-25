using UnityEngine;

[CreateAssetMenu(menuName = "AttackType/Melee")]
public class MeleeAttackConfig : AttackTypeConfig
{
    [SerializeField, Range(1, 10)] private float damage;
    public override AttackProvider SetAttack(Enemy enemy)
    {
        attackProvider = new MeleeAttack(enemy.animator, coolDown,damage);
        return base.SetAttack(enemy);
    }
}
