using System.Collections.Generic;
using Homebrew;
using UnityEngine;

[CreateAssetMenu(fileName = "DataRoguelikeGameSession", menuName = "Data/DataRoguelikeGameSession")]
public class DataRoguelikeGameSession : DataGame
{
   
    [FoldoutGroup("Level", true), SerializeField]
    public float levelStartDelay = 2f;
    public float restartDelay = 1f;
    public float turnDelay = 0.1f;
    public int level = 1;
    public int food = 100;


    [FoldoutGroup("Board", true), SerializeField]
    public int columns = 8;
    public int rows = 8;
    public DataCount wallCount = new DataCount(5, 9);
    public DataCount foodCount = new DataCount(1, 5);
    
    [HideInInspector] public List<Actor> enemies = new List<Actor>();
    
    [HideInInspector] public bool playersTurn = true;
    [HideInInspector] public bool enemiesMoving = false;
    [HideInInspector] public bool enabled = true;
}