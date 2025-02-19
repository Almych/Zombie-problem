using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackDealer : IAttackDealer
{
    private Sprite _bulletSprite;
    private float _damage;
    private float _bulletSpeed;
    private Transform _enemyTransform;
    public RangedAttackDealer(float damage, Sprite bulletSprite, float bulletSpeed, Transform transform)
    {
        _damage = damage;
        _bulletSprite = bulletSprite;
        _bulletSpeed = bulletSpeed;
        _enemyTransform = transform;
    }
    public void Attack()
    {
        EnemyBulletBehaivior bullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (bullet != null)
        {
            bullet.transform.position = _enemyTransform.position;
            bullet.Activate(_damage, _bulletSprite, _bulletSpeed);
        }
    }
}
