using System.Collections;
using System.Collections.Generic;
using Homebrew;
using UnityEngine;

[CreateAssetMenu(fileName = "DataRoguelikeGameSession", menuName = "Data/DataRoguelikeGameSession")]
public class DataRoguelikeGameSession : DataGame {

	public List<Actor> spawners = new List<Actor>();
	public List<Actor> enemies = new List<Actor>();
	public int score;
}
