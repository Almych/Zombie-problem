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
       Entity enemy = collider.GetComponent<Entity>();
        if (enemy != null)
        {
            isTriggered = true;
            enemy.TakeDamage(_bulletConfig.damage);
            Deactivate();
        }
    }
}
