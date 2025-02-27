public class MoveBoostDecorator : IMovable
{
    private IMovable _movable;
    private float _boostMultiplier;

    public MoveBoostDecorator(IMovable movable, float boostMultiplier)
    {
        _movable = movable;
        _boostMultiplier = boostMultiplier;
    }

    public MoveStats GetStats()
    {
       return _movable.GetStats();
    }

    public void Move()
    { 
        MoveStats stats = _movable.GetStats();
         stats._speed *= _boostMultiplier;
        _movable.Move();
    }

    public void StopMove()
    {
        _movable.StopMove();
    }
}
