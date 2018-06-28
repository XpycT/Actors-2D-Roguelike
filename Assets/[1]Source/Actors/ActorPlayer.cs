using Homebrew;
using UnityEngine;


public class ActorPlayer : Actor, ITick
{
    [FoldoutGroup("Setup")] public DataMove dataMove;

    protected override void Setup()
    {
        Add(dataMove);

        Add<DataRaycast>();
        Add<BehaviorInput>();
        Add<BehaviorMove>();
        Add<BehaviorChop>();

        tags.Add(Tag.GroupPlayers);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.HasTag(Tag.GroupFood) || other.HasTag(Tag.GroupSoda))
        {
            var actor = other.GetComponentInChildren<Actor>();
            actor.SignalDispatch(new SignalInteract {other = this});
        }

        if (other.HasTag(Tag.GroupExit))
        {
            ProcessingSignals.Default.Send(new SignalNextLevel {});
        }
    }
}