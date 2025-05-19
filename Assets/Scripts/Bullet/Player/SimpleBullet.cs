using UnityEngine;

public class SimpleBullet : BulletBehaivior
{
    private bool isTriggered;

    public override void Activate(PlayerBulletConfig bulletConfig)
    {
        isTriggered = false;
        base.Activate(bulletConfig);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (isTriggered)
            return;
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            isTriggered = true;
            _bulletConfig.damage.MakeDamage(enemy);
            Deactivate();
        }
    }
}
