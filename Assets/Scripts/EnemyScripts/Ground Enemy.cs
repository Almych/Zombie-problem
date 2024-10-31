using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundEnemy : Enemy, DiagnolMovable
{
    public DiagnolMovable.Diagnol moveDiagnol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            var barrier = collision.collider.GetComponent<HealthBar>();
            isAttacking = true;
            StartCoroutine(Attack(barrier));
        }
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            isAttacking = false;
            moveDiagnol?.Invoke();
        }
    }

    public override void Initiate()
    {
        rb.velocity = -transform.right * speed;
    }



    public void GetAngryAbility(float speed)
    {
        speed += 1;
    }

    void DiagnolMovable.MoveDiagnol()
    {
        
    }
}
