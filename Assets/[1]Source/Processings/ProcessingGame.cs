using System.Collections;
using Homebrew;
using TMPro;
using UnityEngine;

public class ProcessingGame : ProcessingBase, IMustBeWipedOut, ITick, IReceive<SignalNextLevel>
{
    private bool doingSetup;
    private DataRoguelikeGameSession session;
    private TextMeshProUGUI labelLevel;

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
        labelLevel = ProcessingScene.Default.Get("obj_level/LevelImage/LevelText").GetComponent<TextMeshProUGUI>();
        var level = session.level;
        labelLevel.text = "Day " + level;

        Timer.Add(session.levelStartDelay,
            () => { ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(false); });
    }

    public void Tick()
    {
        CheckIfGameOver();
        
        if (session.playersTurn || session.enemiesMoving || doingSetup)
            return;

        //Start moving enemies.
        Toolbox.Instance.StartCoroutine(MoveEnemies());
    }
    
    IEnumerator MoveEnemies()
    {
        session.enemiesMoving = true;
        yield return new WaitForSeconds(session.turnDelay);

        if (session.enemies.Count == 0)
        {
            yield return new WaitForSeconds(session.turnDelay);
        }

        //Loop through List of Enemy objects.
        for (int i = 0; i < session.enemies.Count; i++)
        {
            //Call the MoveEnemy function of Enemy at index i in the enemies List.
            ActorEnemy enemy = session.enemies[i] as ActorEnemy;
            enemy.Get<BehaviorAI>().MoveEnemy();

            //Wait for Enemy's moveTime before moving next Enemy, 
            yield return new WaitForSeconds(enemy.dataMove.moveTime);
        }

        session.playersTurn = true;
        session.enemiesMoving = false;
    }
    
    private void CheckIfGameOver()
    {
        if (session.food <= 0)
        {
            Toolbox.Get<FactorySounds>().Spawn(Tag.SoundGameOver, .8f);
            ProcessingScene.Default.Get("[KERNEL]/obj_music").GetComponent<AudioSource>().Stop();
            
            labelLevel.text = "After " + session.level + " days, you starved.";
            ProcessingScene.Default.Get("[SCENE]/Objects/obj_level").gameObject.SetActive(true);
            
            session.enabled = false;
        }
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