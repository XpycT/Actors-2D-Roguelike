
using Homebrew;
using UnityEditor.Experimental.UIElements.GraphView;

[System.Serializable]
public class DataCount : IData {
	
	public int minimum;
	public int maximum;

	public DataCount(int min, int max)
	{
		this.minimum = min;
		this.maximum = max;
	}
	
	public void Dispose()
	{
	}
}
