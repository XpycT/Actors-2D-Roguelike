using Homebrew;
using TMPro;

public class ComponentScore : MonoCached, IReceive<SignalChangeScore>
{
    public TextMeshProUGUI label;
    
    public override void OnEnable()
    {
        if (state.HasState(EntityState.OnHold)) return;
        base.OnEnable();
        ProcessingSignals.Default.Add(this);
    }
    
    public override void OnDisable()
    {
        base.OnDisable();
        ProcessingSignals.Default.Remove(this);
    }
    
    public void HandleSignal(SignalChangeScore arg)
    {
        Toolbox.Get<DataRoguelikeGameSession>().playerFoodPoints += arg.score;
        label.text = "Food: "+Toolbox.Get<DataRoguelikeGameSession>().playerFoodPoints;
    }
}