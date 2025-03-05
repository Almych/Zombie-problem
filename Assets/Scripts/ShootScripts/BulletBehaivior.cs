using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaivior : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private bool isTriggered;
    private Damage _damage;

    

    public void Activate(Sprite bullet, Vector3 shootPoint, Damage damage, float speedOfBullet)
    {
        GetComponent<SpriteRenderer>().sprite = bullet;
        _damage = damage;
        transform.position = shootPoint;
        rb.velocity = transform.right * speedOfBullet; 
        isTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered) return;
        if (collision.GetComponent<Entity>() != null)
        {
            isTriggered = true;
            collision.GetComponent<Entity>().TakeDamage(_damage);
            Deactivate();
        }
    }

    public void Deactivate()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false); 
    }
}
