using DG.Tweening;
using System;
using UnityEngine;

public class GrenadeThrowable : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    private const float radius = 5f;
    private Damage _applyDamage;
    private Collider2D[] results = new Collider2D[10];
    private ParticleSystem grenadeParticle;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetGrenadeEffect(Damage applyDamage, ParticleSystem grenadeParticle, Sprite sprite)
    {
        _applyDamage = applyDamage;
        SpriteRenderer.sprite = sprite;
        this.grenadeParticle = grenadeParticle;
    }
    public void Throw(Vector3 targetPosition, float moveDuration)
    {
        transform.DOKill(); //reset dotween animation
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
}
