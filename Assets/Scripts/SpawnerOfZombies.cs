using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfZombies : MonoBehaviour
{
    [SerializeField] private ZombiePool zombiePool;
    [SerializeField] private List<AverageZombie> allowedZombie;
    [SerializeField] private int averageZombie, longZombie, speedyZombie, bigZombie;

    private int maxAmountZombies;
    private float callZombieInterval = 4f;
    private int prevPos;

    private void Start()
    {
        maxAmountZombies = averageZombie + longZombie + speedyZombie + bigZombie;
        StartCoroutine(CallZombieWaves());
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
            Debug.Log($"Remaining Zombies: {maxAmountZombies}");

            CallZombieType(allowedZombie[0], ref averageZombie);
            CallZombieType(allowedZombie[1], ref longZombie);
            CallZombieType(allowedZombie[2], ref speedyZombie);
            CallZombieType(allowedZombie[3], ref bigZombie);

            yield return new WaitForSeconds(callZombieInterval);
        }
        Debug.Log("Zombie is ended");
    }

    private void CallZombieType(AverageZombie zombieType, ref int amount)
    {
        int leftAmount = Mathf.Min(Random.Range(0, amount+1), amount);

        for (int i = 0; i < leftAmount; i++)
        {
            ChangePosition(out Vector3 positionZombie);
            AverageZombie zombie = zombiePool.GetZombie(zombieType);
            zombie.transform.position = positionZombie;
            zombie.Move(zombie.GetComponent<Rigidbody2D>());
            amount--;
            maxAmountZombies--;
        }
    }

    private  float CorrectRandom( int min,  int max)
    {
        var value = 0;
        for (int i = min; i <= max; i++)
        {
            if (prevPos != i)
            {
                prevPos = i;
                value = prevPos;
                return value;
            }
            
        }
        Debug.Log(value);
        return value;
    }
}
