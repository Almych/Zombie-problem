using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ZombieType
{
    public Enemy.EnemyType type;
    /*
    private Enemy enemy;
    public Enemy Str()
    {
        switch (type)
        {
            case Enemy.EnemyType.Grounder: enemy = new GroundEnemy(damage: 3f, health: 10f); break;
            case Enemy.EnemyType.Flyer: Debug.Log("Flyer"); break;
            case Enemy.EnemyType.LongRange: Debug.Log("LongRange"); break;

        }
        return enemy;
    }
    */
}
public class MainEnemy : MonoBehaviour
{
   [SerializeField] public ZombieType type;
    private void Start()
    {
       // Debug.Log(type.Str());
    }
}
