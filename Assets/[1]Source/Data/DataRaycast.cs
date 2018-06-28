using Homebrew;
using UnityEngine;

public class DataRaycast : IData
{
    public RaycastHit2D hit;
    public RaycastHit2D[] hits = new RaycastHit2D[4];
    public int amount;
		
    public void Dispose()
    {
        hits = new RaycastHit2D[0];
    }
}