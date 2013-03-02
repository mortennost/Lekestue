using UnityEngine;
using System.Collections;

public class AIStateStructurePlacement : State {

	public AIStateStructurePlacement( GameObject gameObject ) : base( gameObject ) {
		
	}	
	
	public override void OnStart()
	{
		GetGameObject().tag = "Untargetable";
	}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop()
	{
		//GetGameObject().tag = "Structure";
	}
	
	public override void OnExecute() {
		
		
	}	
}
