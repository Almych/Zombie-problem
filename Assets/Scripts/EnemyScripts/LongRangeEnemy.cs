using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LongRangeEnemy : Enemy
{
    public LayerMask barrier;
    [SerializeField] private float distance;
    //[SerializeField] private GameObject bulletPrefab;
    private bool isCheckingTarget = true;
    private RaycastHit2D hit;

   

    private async Task CallCheck()
    {
        while(!isDead)
        {
            isAttacking = false;
            await Task.Delay(TimeSpan.FromSeconds(1));
            if (isCheckingTarget)
            {
                CheckTarget();
            }   
        }
    }

    private async void CheckTarget()
    {
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.right, distance, barrier);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<HealthBar>()!= null && !isAttacking)
            {
                Debug.Log("Taken");
                isAttacking = true;
                await SpitPoisen();
            }
        }
    }
   
    private async Task SpitPoisen()
    {
       rb.velocity = Vector2.zero;
       animator.SetBool("isAttacking", isAttacking);
       await Task.Delay(TimeSpan.FromSeconds(1f));
    }

    public override async void Initiate()
    {
        isCheckingTarget = true;
        rb.velocity = -transform.right * speed;
        await CallCheck();
    }

    private void OnDisable()
    {
       isCheckingTarget = false;
    }

}
