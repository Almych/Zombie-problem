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
    private int attackCoolDown;
    private float attackDamage;
    private int currTicks = 0;
    private float _bulletSpeed;
    private Sprite _bulletSprite;
    private Transform _bulletTransform;
    public RangeDealer(float damage, int coolDownTicks, Sprite bulletSprite, float bulletSpeed, Transform shootPoint)
    {
        attackCoolDown = coolDownTicks;
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
