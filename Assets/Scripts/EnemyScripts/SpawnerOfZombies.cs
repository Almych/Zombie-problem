using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

#region StructOfZombie
[Serializable]
public struct ZombieData
{
    public Enemy zombieType;
    public int amount;
}
#endregion

public class SpawnerOfZombies : MonoBehaviour
{
    [SerializeField] private ZombiePoolObject zombiePool;
    private List<ZombieData> zombie;
    private int maxAmountZombies;
    private List<int> prevPos = new List<int>();
    private CancellationTokenSource cancellationSource =  new CancellationTokenSource();
    private void Start()
    {
        zombie = zombiePool.zombiesPrefabs;
        foreach (var zomb in zombie)
        {
            maxAmountZombies += zomb.amount;
        }
    }

    private void OnEnable()
    {
        if (!cancellationSource.IsCancellationRequested)
        {
            ZombieWaves.GetMaxAmount += () => maxAmountZombies;
            ZombieWaves.ZombieWaveChanged += CallZombie;
        }
    }

    private void OnDisable()
    {
        cancellationSource.Cancel();
        ZombieWaves.GetMaxAmount -= () => maxAmountZombies;
        ZombieWaves.ZombieWaveChanged -= CallZombie;
    }

    private void ChangePosition(out Vector3 positionZombie)
    {
        float randomY = CorrectRandom(3, 6);
        positionZombie = new Vector3(transform.position.x, randomY, transform.position.z);
    }

    private async Task CallZombie(int callAmount)
    {       
            while (maxAmountZombies > 0)
            {
                if (cancellationSource.IsCancellationRequested)
                {
                    return;
                }
            foreach (var zomb in zombie)
                {
                    int availableAmount = zomb.amount;
                    await CallZombieType(zomb.zombieType, availableAmount, callAmount);
                }
                await Task.Delay(TimeSpan.FromSeconds(2f));
            }
         Debug.Log("Zombie spawning has ended");
    }


    private async Task<int> CallZombieType(Enemy zombieType, int amount, int callAmount)
    {
        int spawnAmount = Mathf.Min(CorrectRandom(0, amount + 1), callAmount);
        for (int i = 0; i < spawnAmount; i++)
        {
            if (amount <= 0 || maxAmountZombies <= 0) break;

            ChangePosition(out Vector3 positionZombie);
            Enemy zombie = zombiePool.GetZombie(zombieType);
            if (zombie != null)
            {
                zombie.transform.position = positionZombie;
                zombie.Initiate();
                amount--;
                maxAmountZombies--;
            }

           
            await Task.Delay(TimeSpan.FromSeconds(2f)); 
        }
        return amount;
    }

    

    #region CorrectRandomZombie
    private int CorrectRandom(int min, int max)
    {
        if (prevPos.Count >= (max - min + 1))
        {
            prevPos.Clear();
        }

        int value;
        do
        {
            value = UnityEngine.Random.Range(min, max + 1);
        } while (prevPos.Contains(value));

        prevPos.Add(value);
        return value;
    }
    #endregion
}
