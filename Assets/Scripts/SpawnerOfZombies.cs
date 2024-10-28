using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region StructOfZombie
[Serializable]
public struct ZombieData
{
    public AverageZombie zombieType;
    public int amount;
}
#endregion

public class SpawnerOfZombies : MonoBehaviour
{
   [SerializeField] private ZombiePoolObject zombiePool;
    private List<ZombieData> zombie;
    private int maxAmountZombies;
    private float callZombieInterval = 4f;
    private List<int> prevPos = new List<int>();
    private int amount;

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
        ZombieWaves.GetMaxAmount += () => maxAmountZombies;
        ZombieWaves.ZombieWaveChanged += CallZombie;
    }

    private void OnDisable()
    {
        ZombieWaves.GetMaxAmount -= () => maxAmountZombies;
        ZombieWaves.ZombieWaveChanged -= CallZombie;
    }
    private void ChangePosition(out Vector3 positionZombie)
    {
        float randomY = CorrectRandom(3, 6);
        positionZombie = new Vector3(transform.position.x, randomY, transform.position.z);
    }

    private IEnumerator CallZombie(int callAmount)
    {
        while (maxAmountZombies > 0)
        {
            for (int i = 0; i < zombie.Count; i++)
            { 
                    amount = zombie[i].amount;
                CallZombieType(zombie[i].zombieType, ref amount, callAmount);
            }
            yield return new WaitForSeconds(callZombieInterval);
        }
        Debug.Log("Zombie spawning has ended");
    }



    private void CallZombieType(AverageZombie zombieType, ref int amount,  int callAmount)
    {
        int leftAmount = Mathf.Min(CorrectRandom(0, amount + 1), amount);
        if (callAmount <= amount)
        {
            for (int i = 0; i < callAmount; i++)
            {
                ChangePosition(out Vector3 positionZombie);
                AverageZombie zombie = zombiePool.GetZombie(zombieType);
                if (zombie != null)
                {
                    zombie.transform.position = positionZombie;
                    zombie.Move(zombie.GetComponent<Rigidbody2D>());
                    amount--;
                    maxAmountZombies--;
                }
            }
        }
        else
        {
            Debug.Log("Limit is reached");
        }
       
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


