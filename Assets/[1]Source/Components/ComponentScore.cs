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
        
        updateScore();
    }

    private void updateScore()
    {
        label.text = "Food: " + Toolbox.Get<DataRoguelikeGameSession>().food;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        ProcessingSignals.Default.Remove(this);
    }
    
    public void HandleSignal(SignalChangeScore arg)
    {
        Toolbox.Get<DataRoguelikeGameSession>().food += arg.score;
        updateScore();
    }
}