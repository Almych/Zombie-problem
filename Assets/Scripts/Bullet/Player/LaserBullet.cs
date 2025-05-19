using UnityEngine;

public class LaserBullet : BulletBehaivior
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            _bulletConfig.damage.MakeDamage(enemy);
        }
    }
}
