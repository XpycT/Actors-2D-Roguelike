/*===============================================================
Product:    Unity3dTools
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       5/21/2018 9:08 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorInput : Behavior, ITick
	{
		[Bind] private DataMove dataMove;

		public override void OnTick()
		{
			dataMove.x = (int) (Input.GetAxisRaw("Horizontal"));
			dataMove.y = (int) (Input.GetAxisRaw("Vertical"));
			
			if(dataMove.x != 0)
			{
				dataMove.y = 0;
			}
		}
	}
}