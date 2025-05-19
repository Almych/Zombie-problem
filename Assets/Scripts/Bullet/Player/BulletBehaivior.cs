using System.Collections;
using UnityEngine;

public abstract class BulletBehaivior : BaseBulletBehaviour
{
     protected PlayerBulletConfig _bulletConfig;
   

    public void InitConfig()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public virtual void Activate(PlayerBulletConfig bulletConfig)
    {
        _bulletConfig = bulletConfig;
        spriteRenderer.sprite = _bulletConfig.bulletSprite;
        rb.linearVelocity = transform.right * _bulletConfig.speed;
        StartCoroutine(BulletFlow());
    }
    
    protected IEnumerator BulletFlow()
    {
        yield return new WaitForSeconds(_bulletConfig.bulletLifeTime);
        Deactivate();
    }
}
