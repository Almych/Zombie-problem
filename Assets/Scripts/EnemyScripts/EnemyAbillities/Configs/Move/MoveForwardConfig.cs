
using UnityEngine;

[CreateAssetMenu(menuName ="MoveType/Forward")]
public class MoveForwardConfig : MoveTypeConfig
{
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new MoveTowards(enemy);
        return base.SetMove(enemy);
    }
}
