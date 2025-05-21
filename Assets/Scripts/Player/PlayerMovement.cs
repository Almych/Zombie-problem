using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        Init();
        UpdateSystem.OnUpdate += Tick;
    }

    private void OnDestroy()
    {
        UpdateSystem.OnUpdate -= Tick;
    }

    private void Tick()
    {

        moveInput = new Vector2(0f, Input.GetAxis("Vertical"));
        animator.SetBool("isMove", moveInput.sqrMagnitude > 0);
    }

    private void FixedUpdate()
    {
            rb.linearVelocity = moveInput * speed;
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
