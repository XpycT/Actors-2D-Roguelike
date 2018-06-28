using System.Collections;
using Homebrew;
using TMPro;
using UnityEngine;

public class ProcessingGame : ProcessingBase, IMustBeWipedOut, ITick, IReceive<SignalNextLevel> {

    private bool doingSetup;
    private DataRoguelikeGameSession session;

    public ProcessingGame()
    {
        doingSetup = true;
        session = Toolbox.Get<DataRoguelikeGameSession>();
        InitGame();
        session.enabled = true;
        doingSetup = false;
    }

    private void InitGame()
    {
        ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(true);
        var labelLevel = ProcessingScene.Default.Get("obj_level/LevelImage/LevelText").GetComponent<TextMeshProUGUI>();
        var level = session.level;
        labelLevel.text = "Day " + level;
        
        Timer.Add(session.levelStartDelay, () =>
        {
            ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(false);
        });
    }

    public void Tick()
    {
        if(session.playersTurn || session.enemiesMoving || doingSetup)
            return;
			
        //Start moving enemies.
        Toolbox.Instance.StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies()
    {
        session.enemiesMoving = true;
        
        yield return new WaitForSeconds(session.turnDelay);
        
        yield return new WaitForSeconds(session.turnDelay);
        
        session.playersTurn = true;
        session.enemiesMoving = false;
        
    }

    public void HandleSignal(SignalNextLevel arg)
    {
        session.enabled = false;
        
        Timer.Add(session.restartDelay, () =>
        {
            session.playersTurn = true;
            session.level++;
            Scenes.sceneGame.To();
        });
    }
}
