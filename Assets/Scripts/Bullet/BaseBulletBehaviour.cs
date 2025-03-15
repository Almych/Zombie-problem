
using UnityEngine;

public abstract class BaseBulletBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected float speed;
    void Awake()
    {
        Init();
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public abstract void OnTriggerEnter2D(Collider2D collider);
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
