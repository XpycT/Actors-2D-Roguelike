using Homebrew;
using UnityEngine;

public class ActorFood : Actor
{
    [FoldoutGroup("Setup", true)] 
    public DataFood dataFood;
    public DataTag dataTag;

    protected override void Setup()
    {
        Add(dataFood);
        Add(dataTag);
        Add<BehaviorInteract>();

        tags.Add(Tag.ColliderInteract);
    }

    public class BehaviorInteract : Behavior, IReceive<SignalInteract>
    {
        [Bind] private DataFood dataFood;
        [Bind] private DataTag dataTag;

        public void HandleSignal(SignalInteract arg)
        {
            //var other = arg.other;
            ProcessingSignals.Default.Send(new SignalChangeScore {score = dataFood.food});
            actor.HandleDestroyGO();
            if (dataTag.id == Tag.GroupFood)
            {
                Toolbox.Get<FactorySounds>().Spawn(Tag.SoundEat);
            }
            else
            {
                Toolbox.Get<FactorySounds>().Spawn(Tag.SoundDrink);
            }
        }
    }
}