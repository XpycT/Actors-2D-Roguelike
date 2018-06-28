using System;
using Homebrew;
using UnityEngine;

public class BehaviorChop : Behavior, IReceiveGlobal<SignalTriggerEnter>
{
    [Bind(From.Object)] private Animator anim;
    
    public void HandleSignal(SignalTriggerEnter arg)
    {
        arg.other.GetComponent<ActorWall>().DamageWall();
        anim.SetTrigger ("playerChop");
        Toolbox.Get<FactorySounds>().Spawn(Tag.SoundChops);
    }
}