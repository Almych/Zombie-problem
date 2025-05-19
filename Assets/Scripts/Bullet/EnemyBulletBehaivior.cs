using UnityEngine;

public class EnemyBulletBehaivior : BaseBulletBehaviour
{
    private float damage;
    private float speed;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Activate (float damage, Sprite sprite, float speed, Vector3 pos)
    {
        this.damage = damage;
        this.speed = speed;
        spriteRenderer.sprite = sprite;
        transform.position = pos;
        rb.linearVelocity = -transform.right * speed;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBar health = collision.GetComponent<HealthBar>();
        if ( health != null)
        {
            health.ChangeHealthValue(-damage);
            Deactivate();
        }

    }
}
