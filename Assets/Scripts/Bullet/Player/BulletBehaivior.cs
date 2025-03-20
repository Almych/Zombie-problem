using System.Collections;
using UnityEngine;

public abstract class BulletBehaivior : BaseBulletBehaviour
{
     protected PlayerBulletConfig _bulletConfig;
   

    public void SetConfig(PlayerBulletConfig bulletConfig)
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _bulletConfig = bulletConfig;
        spriteRenderer.sprite = _bulletConfig.bulletSprite;
    }
    public virtual void Activate()
    {
        rb.velocity = transform.right * _bulletConfig.speed;
        StartCoroutine(BulletFlow());
    }
    
    protected IEnumerator BulletFlow()
    {
        yield return new WaitForSeconds(_bulletConfig.bulletLifeTime);
        Deactivate();
    }
}
