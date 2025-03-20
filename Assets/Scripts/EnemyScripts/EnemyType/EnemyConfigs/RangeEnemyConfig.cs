
using UnityEngine;
[CreateAssetMenu(fileName = "New RangeEnemyConfig", menuName ="EnemyConfig/RangeEnemyConfig")]
public class RangeEnemyConfig : BaseEnemyConfig
{
    public float detectRange;
    public LayerMask player;
    public EnemyBulletConfig bulletConfig;
}
