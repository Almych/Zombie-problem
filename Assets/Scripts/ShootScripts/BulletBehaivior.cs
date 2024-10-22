using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    public delegate float DamageGet();
    public DamageGet Damage;
    private float speedBullet = 20f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Activate()
    {
        rb.velocity = transform.right * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AverageZombie>() != null)
        {
            var zombie = collision.GetComponent<AverageZombie>();
            zombie.GetDamage(Damage());
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            Deactivate();
        }
        else if (collision.GetComponent<WallTrigger>()!= null)
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }


}
