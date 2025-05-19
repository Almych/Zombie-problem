
using UnityEngine;

[CreateAssetMenu(menuName = "MoveType/None")]
public class NoneMoveConfig : MoveTypeConfig
{
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new NoneMove(enemy, 0f);
        return base.SetMove(enemy);
    }
}
