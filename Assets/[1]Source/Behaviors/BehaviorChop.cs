using System;
using Homebrew;
using UnityEngine;

public class BehaviorChop : Behavior, IReceiveGlobal<SignalTriggerEnter>
{
    [Bind(From.Object)] private Animator anim;

    public void HandleSignal(SignalTriggerEnter arg)
    {
        arg.other.GetComponent<Actor>().SignalDispatch(new SignalDamage {damage = 1});
        anim.SetTrigger("playerChop");
        Toolbox.Get<FactorySounds>().Spawn(Tag.SoundChops);
    }
}