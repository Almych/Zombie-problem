
using UnityEngine;

public abstract class Ability : IAbility
{
    protected Enemy enemy;
    protected int coolDownTicks;
    protected bool callOnce;
    protected int currentTicks;

    protected bool calledAbility;
    protected bool canCall;
    public Ability(int coolDownTicks, bool callOnce, Enemy enemy)
    {
        this.coolDownTicks = coolDownTicks;
        this.callOnce = callOnce;
        this.enemy = enemy;
    }

    public virtual void InvokeAbility()
    {
        if (!callOnce)
        {
            if (currentTicks >= coolDownTicks)
            {
                OnCall();
                currentTicks = 0;
            }
            else
                currentTicks++;
        }
        else
        {
            if (calledAbility)
                return;
            OnCall();
            calledAbility = true;
        }
            
    }


    protected abstract void OnCall();
    public void StopAbility() => canCall = false;
    public void ResetAbility()
    {
        canCall = true;
        calledAbility = false;
    }

   
}
