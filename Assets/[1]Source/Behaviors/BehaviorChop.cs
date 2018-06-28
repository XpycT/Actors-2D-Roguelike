using System;
using Homebrew;
using UnityEngine;

public class BehaviorChop : Behavior, IReceive<SignalTriggerEnter>
{
    [Bind(From.Object)] private Animator anim;
    
    protected override void Setup()
    {
        ProcessingSignals.Default.Add(this);
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        ProcessingSignals.Default.Remove(this);
    }
    
    public void HandleSignal(SignalTriggerEnter arg)
    {
        arg.other.GetComponent<ActorWall>().DamageWall();
        anim.SetTrigger ("playerChop");
        Toolbox.Get<FactorySounds>().Spawn(Tag.SoundChops);
    }
}