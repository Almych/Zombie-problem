using UnityEngine;
[CreateAssetMenu(menuName = "MoveType/ZigZag")]
public class ZigZagConfig : MoveTypeConfig
{
    [SerializeField, Range(0, 3)] private float amplitude, frequence;
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new ZigZagMove(enemy.animator,enemy.transform, enemy.rb, enemy.enemyConfig.speed, amplitude, frequence);
        return base.SetMove(enemy);
    }
}
