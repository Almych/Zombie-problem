using UnityEngine;
[CreateAssetMenu(menuName = "MoveType/ZigZag")]
public class ZigZagConfig : MoveTypeConfig
{
    [SerializeField, Range(0, 3)] private float amplitude, frequence;
    public override MoveProvider SetMove(Enemy enemy)
    {
        moveProvider = new ZigZagMove(enemy, amplitude, frequence);
        return base.SetMove(enemy);
    }
}
