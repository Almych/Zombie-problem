using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bleed Damage", menuName = "Damage/Bleed Damage")]
public class BleedDamage : Damage
{
    [Range(1, 3)][SerializeField] private float timeBleeding;
    private const float remainTime = 1f;
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public async override void MakeDamage(Action<float> DoEnemyDamage, Entity enemy)
    {
         float bleedTime = timeBleeding;
        DoEnemyDamage?.Invoke(damage);
        if (enemy.isActiveAndEnabled)
        {
            while (bleedTime > 0f && !cancellationTokenSource.IsCancellationRequested)
            {
                Debug.Log("bleeding");
                DoEnemyDamage(damage / damage);
                await Task.Delay(TimeSpan.FromSeconds(remainTime));
                bleedTime -= 0.5f;
            }
        }
    }


    private void OnDisable()
    {
        cancellationTokenSource?.Cancel();
    }

}
