using Homebrew;

public class BehaviorGrab : Behavior, IReceive<SignalTriggerEnter>
{
    public void HandleSignal(SignalTriggerEnter arg)
    {
        var hit = arg.other;
        var hitActor = hit.GetActor(Tag.ColliderInteract);
        if (hitActor == null) return;
        hitActor.SignalDispatch(new SignalInteract {other = actor});
    }
}