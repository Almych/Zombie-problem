
using UnityEngine;

[CreateAssetMenu(menuName ="MoveType/Forward")]
public class MoveForwardConfig : MoveTypeConfig
{
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new MoveTowards(enemy.animator,enemy.transform, enemy.rb, enemy.enemyConfig.speed);
        return base.SetMove(enemy);
    }
}
