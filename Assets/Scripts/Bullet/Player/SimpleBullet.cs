using UnityEngine;

public class SimpleBullet : BulletBehaivior
{
    private bool isTriggered;

    public override void Activate()
    {
        isTriggered = false;
        base.Activate();
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (isTriggered)
            return;
        Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            isTriggered = true;
            enemy.TakeDamage(_bulletConfig.damage);
            Deactivate();
        }
    }
}
