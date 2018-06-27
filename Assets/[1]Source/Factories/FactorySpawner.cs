using System.Collections.Generic;
using Homebrew;
using UnityEngine;

[CreateAssetMenu(fileName = "FactorySpawner", menuName = "Factories/FactorySpawner")]
public class FactorySpawner : Factory
{
	[SerializeField] private List<GameObject> prefabEnemies = new List<GameObject>();
	[SerializeField] private List<GameObject> prefabFloors = new List<GameObject>();
	[SerializeField] private List<GameObject> prefabWalls = new List<GameObject>();
	[SerializeField] private List<GameObject> prefabFoods = new List<GameObject>();
	[SerializeField] private List<GameObject> prefabOuterWalls = new List<GameObject>();
	[SerializeField] private GameObject prefabPlayer;
	[SerializeField] private GameObject prefabExit;

	public override Transform Spawn(int id)
	{
		var prefab = prefabEnemies[id];
		return this.Populate(Pool.None, prefab);
	}
	
	public Transform SpawnExit(Vector3 pos)
	{
		return this.Populate(Pool.None, prefabExit, pos);
	}

	public Transform SpawnPlayer()
	{
		return this.Populate(Pool.None, prefabPlayer, Vector3.zero);
	}

	public Transform SpawnFloor(Vector3 pos)
	{
		var floor = this.Populate(Pool.None, prefabFloors.ReturnRandom(), pos);
		floor.transform.position = new Vector3(pos.x, pos.y, 0);
		return floor;
	}
	
	public void SpawnWall(Vector3 pos)
	{
		var wall = this.Populate(Pool.None, prefabWalls.ReturnRandom(), pos);
		wall.transform.position = new Vector3(pos.x, pos.y, 0);
	}
	
	public void SpawnFood(Vector3 pos)
	{
		var food = this.Populate(Pool.None, prefabFoods.ReturnRandom(), pos);
		food.transform.position = new Vector3(pos.x, pos.y, 0);
	}
	
	public Transform SpawOuterWall(Vector3 pos)
	{
		var outerWall = this.Populate(Pool.None, prefabOuterWalls.ReturnRandom(), pos);
		outerWall.transform.position = new Vector3(pos.x, pos.y, 0);
		return outerWall;
	}
}
