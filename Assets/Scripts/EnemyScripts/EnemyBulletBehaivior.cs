using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaivior : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    private float speed;

    private void Deactivate()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Activate (float damage, Sprite sprite, float speed)
    {
        gameObject.SetActive(true);
        this.damage = damage;
        this.speed = speed;
        spriteRenderer.sprite = sprite;
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthBar>() != null)
        {
            collision.GetComponent<HealthBar>().ChangeHealthValue(-damage);
            Deactivate();
        }

    }
}
