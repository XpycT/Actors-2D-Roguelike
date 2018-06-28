using Homebrew;
using UnityEngine;

public class BehaviorDamagable : Behavior, IReceive<SignalDamage>
{
    [Bind] private DataHP dataHp;
    
    public void HandleSignal(SignalDamage arg)
    {
        Get<SpriteRenderer>().sprite = ((ActorWall)actor).dmgSprite;
        dataHp.hp -= arg.damage;
        if (dataHp.hp <= 0) actor.HandleDestroyGO();
    }
}