using Homebrew;
using UnityEngine;

public class ActorFood : Actor
{
    [FoldoutGroup("Setup")] public DataFood dataFood;

    protected override void Setup()
    {
        Add(dataFood);
        Add<BehaviorInteract>();
        
        tags.Add(Tag.GroupFood);
    }
    
    public class BehaviorInteract : Behavior, IReceive<SignalInteract>
    {
        [Bind] private DataFood dataFood;
        
        public void HandleSignal(SignalInteract arg)
        {
            //var other = arg.other;
            ProcessingSignals.Default.Send(new SignalChangeScore { score = dataFood.food });
            actor.HandleDestroyGO();
            //Toolbox.Get<FactorySounds>().Spawn(Tag.SoundTakeGun,1);
        }
    }
}