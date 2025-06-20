using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Entity : MonoBehaviour, IEntity
{
    internal protected Animator animator { get; private set; }
    internal protected Rigidbody2D rb { get; private set; }
    protected Collider2D enemyCollider;
    protected SpriteRenderer spriteRenderer, bodySprite;

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.childCount > 0)
           bodySprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }



    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
