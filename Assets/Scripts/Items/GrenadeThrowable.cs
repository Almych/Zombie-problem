using System;
using UnityEngine;

public class GrenadeThrowable : MonoBehaviour
{
    private const float radius = 5f;
    private Action<Enemy> OnExplode;
    private Collider2D[] results = new Collider2D[10]; // Reusable buffer

    public void SetGrenadeEffect(Action<Enemy> effect)
    {
        OnExplode = effect;
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

        // Optional visual/sound effects
        Debug.Log("Grenade exploded!");
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
