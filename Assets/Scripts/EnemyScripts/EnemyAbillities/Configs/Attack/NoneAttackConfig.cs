using UnityEngine;

[CreateAssetMenu(menuName = "AttackType/None")]

public class NoneAttackConfig : AttackTypeConfig
{
    public override AttackProvider SetAttack(Enemy enemy)
    {
        attackProvider = new NoneAttack(enemy.animator, coolDown);
        return base.SetAttack(enemy);
    }
}
