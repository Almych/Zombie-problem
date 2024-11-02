using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;



    public class LongRangeEnemy : Enemy, IDiagnolMovable
    {
    public LayerMask barrier;
    [SerializeField] private float distance;
    private bool isCheckingTarget = true;
    private RaycastHit2D hit;

   

    private async Task CallCheck()
    {
        while(!isDead)
        {
            isAttacking = false;
            await Task.Delay(TimeSpan.FromSeconds(attackCoolDown));
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
                isAttacking = true;
                await SpitPoisen();
            }
        }
    }
   
    private async Task SpitPoisen()
    {
       rb.velocity = Vector2.zero;
       animator.SetBool("isAttacking", isAttacking);
        var bullet =EnemyBulletPool.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.Activate(ref damage);
        }
       await Task.Delay(TimeSpan.FromSeconds(attackCoolDown));
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
        OnDamage -= () => MoveDiagnol(1f);
    }
    private void OnEnable()
    {
        OnDamage += ()  => MoveDiagnol(1f);
    }

   

    public async void MoveDiagnol(float coolDownTime)
    {
       
        int direction = UnityEngine.Random.Range(0,3);
        if (direction > 0)
        {
            rb.velocity = -transform.right + transform.up * speed;
            isAttacking = false;
        }
        else if (direction < 1)
        {
            rb.velocity = -transform.right + -transform.up * speed;
            isAttacking = false;
        }

        await Task.Delay(TimeSpan.FromSeconds(coolDownTime));
        isAttacking = true;
    }
}
