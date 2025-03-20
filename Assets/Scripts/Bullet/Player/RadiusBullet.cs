using UnityEngine;

public class RadiusBullet : BulletBehaivior
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_bulletConfig.damage);
            Deactivate();
        }
    }
}
