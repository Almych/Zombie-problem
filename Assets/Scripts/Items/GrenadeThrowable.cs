using DG.Tweening;
using System;
using UnityEngine;

public class GrenadeThrowable : MonoBehaviour
{
    private const float radius = 5f;
    private Damage _applyDamage;
    private Collider2D[] results = new Collider2D[10];
    private ParticleSystem grenadeParticle;
    public void SetGrenadeEffect(Damage applyDamage, ParticleSystem grenadeParticle)
    {
        _applyDamage = applyDamage;
        this.grenadeParticle = grenadeParticle;
        Debug.Log(grenadeParticle.name);
    }
    public void Throw(Vector3 targetPosition, float moveDuration)
    {
        transform.DORotate(new Vector3(0, 0, 360), moveDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart); ;
        transform.DOMove(targetPosition, moveDuration)
                 .SetEase(Ease.Linear)
                 .OnComplete(() =>
                 {
                     ThrowEffect();
                     Explode();
                 });
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
                _applyDamage.MakeDamage(enemy);
            }
        }
        gameObject.SetActive(false);
    }

    public void ThrowEffect()
    {
        var exlodeParticle = ObjectPoolManager.GetObjectFromPool(grenadeParticle);
        if (exlodeParticle != null)
        {
            exlodeParticle.transform.position = transform.position;
            exlodeParticle.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
