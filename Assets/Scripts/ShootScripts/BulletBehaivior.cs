using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    //public float damage { get; private set; }
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
        if (collision.GetComponent<Enemy>() != null)
        {
            Deactivate();
            var zombie = collision.GetComponent<Enemy>();
            collision.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (collision.GetComponent<SpawnerOfZombies>()!= null)
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
