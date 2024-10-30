using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct ZombieType
{
    public EnemyType enemyType;
    
    public Enemy enemy;
    public Enemy Str()
    {
        switch (enemyType)
        {
            case EnemyType.Grounder: enemy = new GroundEnemy(); break;
            case EnemyType.Flyer: Debug.Log("Flyer"); break;
            case EnemyType.LongRange: Debug.Log("LongRange"); break;

        }
        return enemy;
    }
    
}
public class MainEnemy : MonoBehaviour
{
   public ZombieType zombieType;
    private void Start()
    {

        Debug.Log(zombieType.Str());
    }
}
