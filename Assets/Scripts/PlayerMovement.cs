using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 move; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        move = new Vector2(0f, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = move * speed;
    }
}
