using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : AttackProvider
{
    private EnemyBulletConfig _bulletConfig;
    private Transform _bulletTransform;

    public RangeAttack(Animator animator, int attackPerTicks, EnemyBulletConfig enemyBulletConfig, Transform shootPoint) : base(animator, attackPerTicks)
    {
        _bulletConfig = enemyBulletConfig;
        _bulletTransform = shootPoint;
    }

    public override void ExecuteAttack(HealthBar health = null)
    {
        EnemyBulletBehaivior enemyBullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (enemyBullet != null)
        {
            enemyBullet.gameObject.SetActive(true);
            enemyBullet.Activate(_bulletConfig.damage, _bulletConfig.bulletSprite, _bulletConfig.speed, _bulletTransform.position);
        }
    }
}
