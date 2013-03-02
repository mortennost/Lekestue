using UnityEngine;
using System.Collections;

public class AIStateStructureOperational : State {

	public AIStateStructureOperational( GameObject gameObject ) : base( gameObject ) {
		
	}	
	
	public override void OnStart()
	{
		GetGameObject().tag = "Structure";
		
	}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() {
		
		
	}	
}
