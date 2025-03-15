using UnityEngine;

public class BulletBehaivior : BaseBulletBehaviour
{
    private Damage damage;
    public void Activate(Damage damage, float speed, Sprite bulletSprite, Vector3 pos)
    {
        this.damage = damage;
        this.speed = speed;
        spriteRenderer.sprite = bulletSprite;
        transform.position = pos;
        rb.velocity = transform.right * speed;
    }
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Entity>() != null)
        {
            collider.GetComponent<Entity>().TakeDamage(damage);
            Deactivate();
        }
        else if (collider.GetComponent<SpawnManager>() != null)
        {
            Deactivate();
        }
    }
}
