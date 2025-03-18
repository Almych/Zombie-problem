using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDealer : IAttackDealer
{
    private float attackDamage;
    public MeleeDealer(float damage)
    {
        attackDamage = damage;
    }

    public void Attack(HealthBar healthBar)
    {
        healthBar?.ChangeHealthValue(-attackDamage);
    }
}


public class RangeDealer : IAttackDealer
{
    private float attackDamage;
    private float _bulletSpeed;
    private Sprite _bulletSprite;
    private Transform _bulletTransform;
    public RangeDealer(float damage, Sprite bulletSprite, float bulletSpeed, Transform shootPoint)
    {
        attackDamage = damage;
        _bulletSpeed = bulletSpeed;
        _bulletSprite = bulletSprite;
        _bulletTransform = shootPoint;
    }
    public void Attack(HealthBar healthBar)
    {
        EnemyBulletBehaivior enemyBullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (enemyBullet != null)
        {
            enemyBullet.gameObject.SetActive(true);
            enemyBullet.Activate(attackDamage, _bulletSprite, _bulletSpeed, _bulletTransform.position);
        }
    }
}
