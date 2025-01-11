using System.Threading.Tasks;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaivior : MonoBehaviour
{
    private float speedBullet = 20f;
    private Rigidbody2D rb;
    private bool isTriggered;
    private Damage damageType;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Deactivate();
    }

    public async void Activate(Sprite bullet)
    {
        GetComponent<SpriteRenderer>().sprite = bullet;
        rb.velocity = transform.right * speedBullet;
        isTriggered = false;
        await Task.Yield();
    }

   
    public Damage DamageOfBullet(Damage damage)
    {
         damageType = damage;
        return damageType;
    }

    private void OnTriggerEnter2D(Collider2D collision)   
    {
        if (collision.GetComponent<Entity>() != null)
        {

            if (isTriggered) 
            {
                return;
            }

           isTriggered = true;

            Deactivate();
            var zombie = collision.GetComponent<Entity>();
            damageType.MakeDamage(zombie);
           
        }
        else if (collision.GetComponent<WaveManager>() != null)
        {
            Deactivate();
        }
       
    }

  
    

    private void Deactivate()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }


}
