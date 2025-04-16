using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : AttackProvider
{
    private EnemyBulletConfig _bulletConfig;
    private Transform _bulletTransform;

    public RangeDamage(Animator animator, EnemyBulletConfig enemyBulletConfig, Transform shootPoint) : base(animator)
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
