using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfZombies : MonoBehaviour
{
    public static EventHandler<float> OnSpawn;
    [SerializeField] private ZombiePool zombiePool;
    [SerializeField] private List<AverageZombie> allowedZombie;
    [SerializeField] private int averageZombie, longZombie, speedyZombie, bigZombie;

    private int maxAmountZombies;
    private float callZombieInterval = 4f;
    private List<int> prevPos = new List<int>();

    private void Start()
    {
        maxAmountZombies = averageZombie + longZombie + speedyZombie + bigZombie;
        StartCoroutine(CallZombieWaves());
        OnSpawn.Invoke(this, maxAmountZombies);
    }

    private void ChangePosition(out Vector3 positionZombie)
    {
        var randomY = CorrectRandom(3, 6);
        positionZombie = new Vector3(transform.position.x, randomY, transform.position.z);
    }

    private IEnumerator CallZombieWaves()
    {
        while (maxAmountZombies > 0)
        {
            CallZombieType(allowedZombie[0], ref averageZombie);
            CallZombieType(allowedZombie[1], ref longZombie);
            CallZombieType(allowedZombie[2], ref speedyZombie);
            CallZombieType(allowedZombie[3], ref bigZombie);
            OnSpawn.Invoke(this, maxAmountZombies);
            yield return new WaitForSeconds(callZombieInterval);
        }
        Debug.Log("Zombie is ended");
    }

    private void CallZombieType(AverageZombie zombieType, ref int amount)
    {
        int leftAmount = Mathf.Min(CorrectRandom(0, amount+1), amount);

        for (int i = 0; i < leftAmount; i++)
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

}
