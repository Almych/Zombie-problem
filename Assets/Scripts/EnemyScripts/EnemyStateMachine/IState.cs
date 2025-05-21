
public interface IState 
{
    void Enter();
    void Tick();
    void Exit();

    void Freeze(int duration);
    bool isFroze();
    PriorityType PriorityType { get; }
}

