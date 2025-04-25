using UnityEngine;

public abstract class MoveTypeConfig : ScriptableObject
{
    protected MoveProvider moveProvider;
    public virtual MoveProvider SetMove(Enemy enemy)
    {
        return moveProvider;
    }
}
