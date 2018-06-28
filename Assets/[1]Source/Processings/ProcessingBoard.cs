using System.Collections.Generic;
using Homebrew;
using UnityEngine;

public class ProcessingBoard : ProcessingBase, IMustBeWipedOut
{
    private Transform boardHolder;
    private List <Vector3> gridPositions = new List <Vector3> ();

    private int rows;
    private int columns;
    private FactorySpawner factory;

    public ProcessingBoard()
    {
        rows = Toolbox.Get<DataRoguelikeGameSession>().rows;
        columns = Toolbox.Get<DataRoguelikeGameSession>().columns;
        factory = Toolbox.Get<FactorySpawner>();
        
        //Creates the outer walls and floor.
        BoardSetup();
        //Reset our list of gridpositions.
        InitialiseList ();

        SpawnWallAtRandom();
        SpawnFoodAtRandom();
        SpawnEnemies();

        factory.SpawnExit(new Vector3 (columns - 1, rows - 1, 0f));

        factory.SpawnPlayer();
    }

    private void InitialiseList()
    {
        gridPositions.Clear ();
			
        for(int x = 1; x < columns-1; x++)
        {
            for(int y = 1; y < rows-1; y++)
            {
                gridPositions.Add (new Vector3(x, y, 0f));
            }
        }
    }

    private void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                Vector3 pos = new Vector3(x, y, 0f);
                Transform go;

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    go = factory.SpawOuterWall(pos);
                }
                else
                {
                    go = factory.SpawnFloor(pos);
                }

                go.SetParent(boardHolder);
            }
        }
    }
    
    private void SpawnWallAtRandom()
    {
        int minimum = Toolbox.Get<DataRoguelikeGameSession>().wallCount.minimum;
        int maximum = Toolbox.Get<DataRoguelikeGameSession>().wallCount.maximum;
        int objectCount = Random.Range (minimum, maximum+1);
			
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            factory.SpawnWall(randomPosition);
        }
    }
    
    private void SpawnFoodAtRandom()
    {
        int minimum = Toolbox.Get<DataRoguelikeGameSession>().foodCount.minimum;
        int maximum = Toolbox.Get<DataRoguelikeGameSession>().foodCount.maximum;
        int objectCount = Random.Range (minimum, maximum+1);
			
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            factory.SpawnFood(randomPosition);
        }
    }
    
    private void SpawnEnemies()
    {
        Toolbox.Get<DataRoguelikeGameSession>().enemies.Clear();
        
        int enemyCount = (int)Mathf.Log(Toolbox.Get<DataRoguelikeGameSession>().level, 2f);
        for(int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            var go = factory.SpawnEnemy(randomPosition);
            Toolbox.Get<DataRoguelikeGameSession>().enemies.Add(go.GetComponent<Actor>());
        }
    }
    
    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range (0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt (randomIndex);
        return randomPosition;
    }
}