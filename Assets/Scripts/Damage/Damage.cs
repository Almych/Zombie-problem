using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class Damage : ScriptableObject
{
    [SerializeField] protected float damage;
    public abstract void MakeDamage(Action<float> DoEnemyDamage, Enemy enemy);
}

[CreateAssetMenu(fileName ="New Bleed Damage", menuName ="Damage/Bleed Damage")]
public class BleedDamage : Damage
{
    [Range(3.0f,5.0f)][SerializeField] private float timeBleeding;
    private const float remainTime = 1f;
    private CancellationTokenSource cancellationTokenSource =  new CancellationTokenSource();

    public async override void MakeDamage(Action<float> DoEnemyDamage, Enemy enemy)
    {
        if (!cancellationTokenSource.IsCancellationRequested && enemy.isActiveAndEnabled)
        {
            float bleedTime = timeBleeding;
            DoEnemyDamage?.Invoke(damage);
            while (bleedTime > 0f)
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

[CreateAssetMenu(fileName = "New Crit Damage", menuName = "Damage/Crit Damage")]
public class CritDamage : Damage
{

    [Range(1,5)][SerializeField] private float critChange;
    

    public override void MakeDamage(Action<float> DoEnemyDamage, Enemy enemy)
    {
        float critDamage = UnityEngine.Random.Range(1, 10);
        if (critDamage >= critChange)
        {
            DoEnemyDamage(damage * 2);
        }
        else
        {
            DoEnemyDamage(damage);
        }
    }
}

[CreateAssetMenu(fileName = "New Crit Damage", menuName = "Damage/Froze Damage")]
public class FrozeDamage : Damage
{
    [Range(1, 5)] private float frozeTime;
    private const float frozeChance = 7;

    public override void MakeDamage(Action<float> DoEnemyDamage, Enemy enemy)
    {
        DoEnemyDamage(damage);
        if (enemy.isActiveAndEnabled)
        {
            Debug.Log("Freze");
        }
    }
}