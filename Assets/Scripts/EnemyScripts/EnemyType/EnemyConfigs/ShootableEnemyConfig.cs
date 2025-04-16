using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShootableEnemyConfig", menuName = "EnemyConfig/ShootableConfig")]
public class ShootableEnemyConfig : RangeEnemyConfig
{
    public EnemyBulletConfig bulletConfig;
}
