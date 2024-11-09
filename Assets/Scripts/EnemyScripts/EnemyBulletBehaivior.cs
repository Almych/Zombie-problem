using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaivior : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private float speed = 3f;
    private void Deactivate()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Activate (ref float damage)
    {
        gameObject.SetActive(true);
        this.damage = damage;
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
