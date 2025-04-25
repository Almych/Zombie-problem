using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController
{
    private Dictionary<Ability, AbilityEvents> abilities = new Dictionary<Ability, AbilityEvents>();
    public void AddAbility(Ability ability, AbilityEvents abilityEvents)
    {
        abilities[ability] = abilityEvents;
    }

}

public class AbilityEvents
{
    private Action onDeath, onMove, onAttack, onDetect, onDamage;
    public AbilityEvents(Action onDeath = null, Action onMove = null, Action onAttack = null, Action onDetect = null, Action onDamage = null)
    {
        this.onDeath = onDeath;
        this.onMove = onMove;
        this.onAttack = onAttack;
        this.onDetect = onDetect;
        this.onDamage = onDamage;
    }

    public void CallMoveAbility() => onMove?.Invoke();
    public void CallDetectAbility() => onDetect?.Invoke();
    public void CallDeathAbility() => onDeath?.Invoke();
    public void CallAttackAbility() => onAttack?.Invoke();
    public void CallDamageAbility() => onDamage?.Invoke();
}

//public class AnimationFrame
//{
//    private int frame;
//    private Action callAction;
//    private Animator animator;
//    private int animationHash;

//    public AnimationFrame(int frame, Action actionOnFrame, Animator animator, int animationHash)
//    {
//        this.frame = frame;
//        this.callAction = actionOnFrame;
//        this.animator = animator;
//        this.animationHash = animationHash;

//        AddAnimationEvent();
//    }

//    private void AddAnimationEvent()
//    {
//        var clipInfo = animator.GetCurrentAnimatorClipInfo(0);
//        if (clipInfo.Length == 0) return;

//        var clip = clipInfo[0].clip;

//        var editableClip = UnityEngine.Object.Instantiate(clip);

//        animator.runtimeAnimatorController.animationClips[0] = editableClip; 

//        float eventTime = frame / editableClip.frameRate;

//        AnimationEvent animEvent = new AnimationEvent
//        {
//            functionName = nameof(OnAnimationFrameReached),
//            time = eventTime
//        };

//        editableClip.AddEvent(animEvent);
//    }

//    public void OnAnimationFrameReached()
//    {
//        callAction?.Invoke();
//    }
//}
