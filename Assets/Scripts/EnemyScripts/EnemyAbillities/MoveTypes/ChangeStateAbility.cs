
public class ChangeStateAbility : Ability
{
    private int _changeState;

    public ChangeStateAbility(int coolDownTicks, bool callOnce, Enemy enemy, int changeState) : base(coolDownTicks, callOnce, enemy)
    {
        _changeState = changeState;
    }

    

    protected override void OnCall()
    {
        if (_changeState == 0)
            enemy.stateMachine?.TryTranslate<RunState>();
        else if (_changeState == 1)
            enemy.stateMachine?.TryTranslate<AttackState>();
        else
            enemy.stateMachine?.TryTranslate<DieState>();
    }
}
