using System;
using UnityEngine;

public class GrenadeThrowable : MonoBehaviour
{
    private const float radius = 5f;
    private Action<Enemy> OnExplode;
    private Collider2D[] results = new Collider2D[10];
    private ParticleSystem grenadeParticle;
    public void SetGrenadeEffect(Action<Enemy> effect, ParticleSystem grenadeParticle)
    {
        OnExplode = effect;
        this.grenadeParticle = grenadeParticle;
    }

    [Obsolete]
    public void Explode()
    {
        int hits = Physics2D.OverlapCircleNonAlloc(transform.position, radius, results);
        for (int i = 0; i < hits; i++)
        {
            Enemy enemy = results[i].GetComponent<Enemy>();
            if (enemy != null)
            {
                OnExplode?.Invoke(enemy);
            }
        }
        gameObject.SetActive(false);
    }

    public void ThrowEffect()
    {
        var exlodePErticle = ObjectPoolManager.GetObjectFromPool(grenadeParticle);
        if (exlodePErticle != null)
        {
            exlodePErticle.transform.position = transform.position;
            exlodePErticle.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
