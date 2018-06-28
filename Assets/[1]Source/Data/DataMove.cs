/*===============================================================
Product:    Unity3dTools
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       5/21/2018 9:06 PM
================================================================*/


namespace Homebrew
{
	[System.Serializable]
	public class DataMove : IData, ISetup
	{
		public int x;
		public int y;
		public float moveTime = 0.1f;

		public void Dispose()
		{
		}

		public void Setup(Actor actor)
		{
			this.x = 0;
			this.y = 0;
		}
	}
}