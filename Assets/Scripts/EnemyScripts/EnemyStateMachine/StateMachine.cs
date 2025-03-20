
public class StateMachine 
{
    private State currentState;
    private RunState runState;
    private AttackState attackState;
    private DieState dieState;
    public StateMachine(RunState runState, AttackState attackState, DieState dieState)
    {
        this.runState = runState;
        this.attackState = attackState;
        this.dieState = dieState;
        currentState = runState;
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void OnTick()
    {
        currentState?.Tick();
    }
}
