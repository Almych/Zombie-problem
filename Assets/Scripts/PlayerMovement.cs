using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AnimationClip idle, walk;
    private Rigidbody2D rb;
    private Vector2 move; 
    private Animator animator;
    private Vector2 prevPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        move = new Vector2(0f, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        prevPos = move.normalized;
        rb.velocity = move * speed;
        Animate();
    }

    private void Animate()
    {
        if (move != prevPos)
        {
            animator.Play(walk.name);
        }
        else
        {
            animator.Play(idle.name);
        }
    }
}
