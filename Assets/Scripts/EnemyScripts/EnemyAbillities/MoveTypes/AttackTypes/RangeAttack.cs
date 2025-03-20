using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : IAttackDealer
{
    private EnemyBulletConfig _bulletConfig;
    private Transform _bulletTransform;
    public RangeDamage(EnemyBulletConfig enemyBulletConfig, Transform shootPoint)
    {
       _bulletConfig = enemyBulletConfig;
        _bulletTransform = shootPoint;
    }

    public void ExecuteAttack(HealthBar health = null)
    {
        EnemyBulletBehaivior enemyBullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (enemyBullet != null)
        {
            enemyBullet.gameObject.SetActive(true);
            enemyBullet.Activate(_bulletConfig.damage, _bulletConfig.bulletSprite, _bulletConfig.speed, _bulletTransform.position);
        }
    }
}
