using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivior : MonoBehaviour
{
    private float speedBullet = 20f;
    private Rigidbody2D rb;
    private bool isTriggered;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Deactivate();
    }

    public void Activate()
    {
        rb.velocity = transform.right * speedBullet;
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)   
    {
        if (collision.GetComponent<Enemy>() != null)
        {

            if (isTriggered) 
            {
                return;
            }

           isTriggered = true;

            Deactivate();
            var zombie = collision.GetComponent<Enemy>();
            zombie.GetDamage((int)ShootController.instance.damage);
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
