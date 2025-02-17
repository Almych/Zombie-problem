
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
    internal protected bool isRunning;
    protected float spawnInterval = 4f;
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

    protected IEnumerator Spawn(EnemyData[] enemies)
    {
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
                Entity entity = selectedEnemyType;
                var enemy = ObjectPoolManager.GetObjectFromPool(selectedEnemyType);
                if (enemy != null)
                {
                    Vector2 validPosition = GetRandomPosition();
                    enemy.transform.position = validPosition;
                    enemy.gameObject.SetActive(true);
                    enemy.Activate();
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

    public void ChangeInterval(float interval)
    {
        spawnInterval = interval;
    }

}



    public class SpawnWaveState : SpawnState
    {
   

        public SpawnWaveState(MonoBehaviour mono) : base(mono)
        {
        }

   


        public override void Enter(EnemyData[] enemies)
        {
            ChangeInterval(2f);
            _mono.StartCoroutine(Spawn(enemies));
        }
    }

    public class SpawnPreWaveState : SpawnState
    {

        public SpawnPreWaveState(MonoBehaviour mono) : base(mono)
        {
        }

        public override void Enter(EnemyData[] enemies)
        {
            ChangeInterval(3f);
            _mono.StartCoroutine(Spawn(enemies));
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

