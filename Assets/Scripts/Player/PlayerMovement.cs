using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private bool canNotMove = false;

    private void Awake()
    {
        Init();
        UpdateSystem.OnUpdate += Tick;
        EventBus.Subscribe<OnPauseEvent>(OnPlayerDeath);
    }

    private void OnDestroy()
    {
        UpdateSystem.OnUpdate -= Tick;
        EventBus.UnSubscribe<OnPauseEvent>(OnPlayerDeath);
    }

    private void Tick()
    {
        if (canNotMove) return;

        moveInput = new Vector2(0f, Input.GetAxis("Vertical"));
        animator.SetBool("isMove", moveInput.sqrMagnitude > 0);
    }

    private void FixedUpdate()
    {
        if (!canNotMove)
            rb.velocity = moveInput * speed;
    }

    private void OnPlayerDeath(OnPauseEvent e)
    {
        canNotMove = e.IsPaused;
        rb.velocity = Vector2.zero;
        animator.SetBool("isMove", false);
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
