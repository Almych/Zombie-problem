using UnityEngine;

public class AttackState : State
{
    private int currentTicks;
   
    public AttackState(Animator animator, int animIndex, Enemy enemy) : base(animator, animIndex, enemy)
    {
        
    }

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
        currentTicks = 0;
    }

    public override void Exit()
    {

    }

    public override void Tick()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1f)
        {
            Debug.Log("ticks");
            currentTicks++;


            if (currentTicks >= _enemy.attackDealer.coolDownTIcks)
            {
                _enemy.CallAttackAbility();
                Debug.Log("Called again");
                PlayAnimation(_animationIndex);
                currentTicks = 0;
            }
        }
    }
}
