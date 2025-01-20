using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class SpawnState
{
    protected const float XPOSITION = 20f;
    protected const float YMINPOSITION = 1f;
    protected const float YMAXPOSITION = 6f;
    protected MonoBehaviour _mono;
    public SpawnState(MonoBehaviour mono)
    {
        _mono = mono;
    }
    protected Vector2 GetRandomPosition()
    {
        float randomY = Random.Range(YMINPOSITION, YMAXPOSITION);

        return new Vector2(XPOSITION, randomY);
    }

    public abstract void Enter(EnemyData[] enemies);

    protected Dictionary<Entity, int> GetWaveData(EnemyData[] enemies)
    {

        Dictionary<Entity, int> enemyData = new Dictionary<Entity, int>();

        foreach (var enemy in enemies)
        {
            enemyData.Add(enemy.enemyType, enemy.amount);
        }
        return enemyData;
    }

    protected int GetAmount(EnemyData[] enemies)
    {
        int amount = 0;
        foreach (var enemy in enemies)
        {
            amount += enemy.amount;
        }
        return amount;
    }
}


public class SpawnWaveState : SpawnState
{
    internal protected bool isRunning;
    private const float spawnInterval = 4f;

    public SpawnWaveState(MonoBehaviour mono) : base(mono)
    {
    }

    public IEnumerator SpawnWave(EnemyData[] enemies)
    {
        Debug.Log(enemies.Length);
        isRunning = true;
        int amount = GetAmount(enemies);
        var enemyData = GetWaveData(enemies);
        while (amount >= 0)
        {
            var random = Random.Range(0, enemyData.Count);
            var selectedEnemyType = new List<Entity>(enemyData.Keys)[random];
            int selectedEnemyAmount = enemyData[selectedEnemyType];
            if (selectedEnemyAmount > 0)
            {
                var enemy = EnemyPool.Instance.GetEnemy(selectedEnemyType);
                if (enemy != null)
                {
                    Vector2 validPosition = GetRandomPosition();
                    enemy.transform.position = validPosition;
                    enemy.gameObject.SetActive(true);
                    enemy.Initiate();
                    enemyData[selectedEnemyType]--;
                }
            }
            else
            {
                enemyData.Remove(selectedEnemyType);
            }
            yield return new WaitForSeconds(spawnInterval);
            amount--;
        }
        isRunning = false;
    }


    public override void Enter(EnemyData[] enemies)
    {
        _mono.StartCoroutine(SpawnWave(enemies));
    }
}

public class SpawnPreWaveState : SpawnState
{
    internal protected bool isRunning;
    private const float spawnInterval = 4f;

    public SpawnPreWaveState(MonoBehaviour mono) : base(mono)
    {
    }

    public override void Enter(EnemyData[] enemies)
    {
        _mono.StartCoroutine(SpawnPreWave(enemies));
    }


    public IEnumerator SpawnPreWave(EnemyData[] enemies)
    {
        Debug.Log(enemies.Length);
        isRunning = true;
        int amount = GetAmount(enemies);
        var enemyData = GetWaveData(enemies);
        while (amount >= 0)
        {
            var random = Random.Range(0, enemyData.Count);
            var selectedEnemyType = new List<Entity>(enemyData.Keys)[random];
            int selectedEnemyAmount = enemyData[selectedEnemyType];
            if (selectedEnemyAmount > 0)
            {
                var enemy = EnemyPool.Instance.GetEnemy(selectedEnemyType);
                if (enemy != null)
                {
                    Vector2 validPosition = GetRandomPosition();
                    enemy.transform.position = validPosition;
                    enemy.gameObject.SetActive(true);
                    enemy.Initiate();
                    enemyData[selectedEnemyType]--;
                }
            }
            else
            {
                enemyData.Remove(selectedEnemyType);
            }
            yield return new WaitForSeconds(spawnInterval);
            amount--;
        }
        isRunning = false;
    }


   
}

public class SpawnNoneState : SpawnState
{
    public SpawnNoneState(MonoBehaviour mono) : base(mono)
    {
    }

    public override void Enter(EnemyData[] enemies)
    {
       //spawn none
    }
}

