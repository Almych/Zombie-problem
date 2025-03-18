using UnityEngine;

public class RadiusBullet : BulletBehaivior
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        Entity enemy = collider.GetComponent<Entity>();
        if (enemy != null)
        {
            enemy.TakeDamage(_bulletConfig.damage);
            Deactivate();
        }
    }
}
