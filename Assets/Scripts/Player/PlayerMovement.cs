using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 move;
    private Animator animator;
    private Vector2 prevPos;
    private bool canMove = true;
    public void Init(InitiateEvent e)
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(Move());
    }
    private void OnEnable()
    {
        EventBus.Subscribe<InitiateEvent>(Init, 1);
        EventBus.Subscribe<PlayerDieEvent>(DisableMove);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<PlayerDieEvent>(DisableMove);
        EventBus.UnSubscribe<InitiateEvent>(Init);
    }
    
    

    private IEnumerator Move()
    {
        while (canMove)
        {
            yield return new WaitForSeconds(0.1f);
            move = new Vector2(0f, Input.GetAxis("Vertical"));
            rb.velocity = move * speed;
            prevPos = move.normalized;
            Animate();
        }
    }
    private void Animate()
    {
        if (move != prevPos)
        {
            animator.SetBool("isMove", true);
        }
    }

    public void DisableMove(PlayerDieEvent e)
    {
       canMove = false;
        animator.SetBool("isMove", false);
    }
}
