using UnityEngine;
[CreateAssetMenu(menuName ="AttackType/Range")]
public class RangeAttackConfig : AttackTypeConfig
{
    [SerializeField] private EnemyBulletConfig bulletConfig;
    
    public override AttackProvider SetAttack(Enemy enemy)
    {
        attackProvider = new RangeAttack(enemy.animator, coolDown, bulletConfig, enemy.ShootPoint);
        return base.SetAttack(enemy);
    }
}
