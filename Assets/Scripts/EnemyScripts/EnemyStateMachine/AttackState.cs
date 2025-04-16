using UnityEngine;

public class AttackState : State
{
   
    public AttackState(Animator animator, int animIndex) : base(animator, animIndex)
    {
        
    }

    public override void Enter()
    {
        SetTriggerAnimation(_animationIndex);
    }

    public override void Exit()
    {
       
    }

    public override void Tick()
    {
       
    }
}
