using System.Collections;
using System.Collections.Generic;
using Homebrew;
using UnityEngine;

public class ProcessingBoard : ProcessingBase, IMustBeWipedOut
{
    private Transform boardHolder;

    public ProcessingBoard()
    {
        BoardSetup();
    }

    private void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        var rows = Toolbox.Get<DataRoguelikeGameSession>().rows;
        var columns = Toolbox.Get<DataRoguelikeGameSession>().columns;

        var factory = Toolbox.Get<FactorySpawner>();

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
}