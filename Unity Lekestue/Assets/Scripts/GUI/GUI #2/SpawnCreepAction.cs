using UnityEngine;
using System.Collections;
using iGUI;

public class SpawnCreepAction : iGUIAction {

	
	public override void act(iGUIElement caller)
	{
		GameObject.Find("Creep Spawner").GetComponent<CreepSpawnScript>().SpawnCreep();
	}
}
