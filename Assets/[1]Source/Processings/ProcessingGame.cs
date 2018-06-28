using Homebrew;
using TMPro;

public class ProcessingGame : ProcessingBase, IMustBeWipedOut, ITick, IReceive<SignalNextLevel> {

    public ProcessingGame()
    {
        InitGame();
    }

    private void InitGame()
    {
        ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(true);
        var labelLevel = ProcessingScene.Default.Get("obj_level/LevelImage/LevelText").GetComponent<TextMeshProUGUI>();
        var level = Toolbox.Get<DataRoguelikeGameSession>().level;
        labelLevel.text = "Day " + level;
        
        Timer.Add(Toolbox.Get<DataRoguelikeGameSession>().levelStartDelay, () =>
        {
            ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(false);
        });
    }

    public void Tick()
    {
        
    }

    public void HandleSignal(SignalNextLevel arg)
    {
        Timer.Add(Toolbox.Get<DataRoguelikeGameSession>().restartDelay, () =>
        {
            //Toolbox.Get<DataRoguelikeGameSession>().playersTurn = false;
            Scenes.sceneGame.To();
        });
    }
}
