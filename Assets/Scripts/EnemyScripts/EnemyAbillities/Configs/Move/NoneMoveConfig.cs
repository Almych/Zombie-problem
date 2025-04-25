
using UnityEngine;

[CreateAssetMenu(menuName = "MoveType/None")]
public class NoneMoveConfig : MoveTypeConfig
{
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new NoneMove(enemy.animator,enemy.transform, enemy.rb, 0f);
        return base.SetMove(enemy);
    }
}
