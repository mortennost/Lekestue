using UnityEngine;
using System.Collections;
using iGUI;

public class EnableMenuState : iGUIAction {

	public override void act(iGUIElement caller)
	{
		GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.enabled = false;
		GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnHarvest.enabled = false;
		
		GameObject.Find("4-CancelBuilding Button").GetComponent<iGUIButton>().onClick[0].act(caller);
		GameObject.Find("4-CancelBuilding Button").GetComponent<iGUIButton>().onClick[1].act(caller);
		
		GameObject.Find("GameStateManager").GetComponent<GameStateManager>().PushState(new MenuState(GameObject.Find("GameStateManager")));
	}
}
