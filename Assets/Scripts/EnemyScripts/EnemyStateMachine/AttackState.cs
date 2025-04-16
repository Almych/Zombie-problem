using UnityEngine;

public class AttackState : State
{
   
    public AttackState(Animator animator) : base(animator)
    {
        
    }

    public override void Enter()
    {
        SetTriggerAnimation(attackAnimation);
    }

    public override void Exit()
    {
       
    }

    public override void Tick()
    {
       
    }
}
