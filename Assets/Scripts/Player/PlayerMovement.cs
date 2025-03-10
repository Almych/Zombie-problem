using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private Animator animator => GetComponent<Animator>();
    private Vector2 moveInput;
    private bool canMove = true;

    private void Init(InitiateEvent e)
    {
        canMove = true;
    }

    private void OnEnable()
    {
        EventBus.Subscribe<InitiateEvent>(Init, 3);
        EventBus.Subscribe<PlayerDieEvent>(OnPlayerDeath);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<InitiateEvent>(Init);
        EventBus.UnSubscribe<PlayerDieEvent>(OnPlayerDeath);
    }

    private void Update()
    {
        if (!canMove) return;

        moveInput = new Vector2(0f, Input.GetAxis("Vertical"));
        animator.SetBool("isMove", moveInput.sqrMagnitude > 0);
    }

    private void FixedUpdate()
    {
        if (canMove)
            rb.velocity = moveInput * speed;
    }

    private void OnPlayerDeath(PlayerDieEvent e)
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        animator.SetBool("isMove", false);
    }
}
