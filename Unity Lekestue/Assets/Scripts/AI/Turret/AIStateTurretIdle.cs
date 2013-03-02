using UnityEngine;
using System.Collections;

public class AIStateTurretIdle : State {

	public AIStateTurretIdle( GameObject gameObject ) : base( gameObject ) {
		
	}
	
	public override void OnStart() {}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() {
		
		
		
		//print( gameObject.tag + " is looking for target" );
		
		GameObject tempTarget = GetGameObject().GetComponent<Target>().FindNearestTarget( "Enemy" );
		if ( tempTarget != null )
		{
			GetGameObject().GetComponent<Target>().SetTarget( tempTarget );
			
			GetGameObject().GetComponent<TurretStateManager>().ChangeState( new AIStateTurretAttack( GetGameObject () ) );
			
		} else {
			//GetGameObject().GetComponentInChildren<Animator>().SetBool( "isAttacking", false );
		}
	}
}
