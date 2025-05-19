
public interface IState 
{
    void Enter();
    void Tick();
    void Exit();

    PriorityType PriorityType { get; }
}

