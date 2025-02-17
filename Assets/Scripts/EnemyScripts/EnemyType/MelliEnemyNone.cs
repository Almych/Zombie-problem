using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MelliEnemyNone : Entity
{
    protected HealthBar barrier;

  
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null)
        {
            barrier = collision.collider.GetComponent<HealthBar>();
        }
    }



   
}
