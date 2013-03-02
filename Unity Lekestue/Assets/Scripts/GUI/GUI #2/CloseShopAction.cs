using UnityEngine;
using System.Collections;
using iGUI;

public class CloseShopAction : iGUIAction 
{
	public override void act(iGUIElement act)
	{
		GameObject.Find("GameStateManager").GetComponent<GameStateManager>().ChangeState(new PlayState(GameObject.Find("GameStateManager")));
	}
}
