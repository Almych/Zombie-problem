using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private bool canMove = true;

    private void Awake()
    {
        Init();
        TickSystem.OnTick += Tick;
        EventBus.Subscribe<OnPauseEvent>(OnPlayerDeath);
    }

    private void OnDestroy()
    {
        TickSystem.OnTick -= Tick;
        EventBus.UnSubscribe<OnPauseEvent>(OnPlayerDeath);
    }

    private void Tick()
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

    private void OnPlayerDeath(OnPauseEvent e)
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        animator.SetBool("isMove", false);
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
