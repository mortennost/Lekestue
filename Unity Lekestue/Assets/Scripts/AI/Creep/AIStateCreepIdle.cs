using UnityEngine;
using System.Collections;

public class AIStateCreepIdle : State {

	public AIStateCreepIdle( GameObject gameObject ) : base( gameObject ) {
		
	}
	
	public override void OnStart() {}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() { 
		
		
		Debug.Log( GetGameObject().tag + " is looking for target" );
		
		GameObject tempTarget = GetGameObject().GetComponent<Target>().FindNearestTarget( "Structure" );
		if ( tempTarget != null )
		{			
			GetGameObject().GetComponent<Target>().SetTarget( tempTarget );
			
			GetGameObject().GetComponent<CreepStateManager>().ChangeState( new AIStateCreepChase( GetGameObject () ) );
			
		} else {
			GetGameObject().GetComponent<Move>()._hasPath = false;
		}
	}
}
