using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    private float speedBullet = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieController>() != null)
        {
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.SetActive(false);
        }
        else if (collision.GetComponent<WallTrigger>()!= null)
        {
            gameObject.SetActive(false);
        }
    }


}
