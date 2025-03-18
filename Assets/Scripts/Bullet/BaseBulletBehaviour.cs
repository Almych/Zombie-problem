
using UnityEngine;

public abstract class BaseBulletBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected BulletConfig config;

    
    public abstract void OnTriggerEnter2D(Collider2D collider);
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
