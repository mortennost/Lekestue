using UnityEngine;
using System.Collections;

public class AIStateCreepChase : State {
	
	public AIStateCreepChase( GameObject gameObject ) : base( gameObject ) {
		
	}
	
	public override void OnStart() {
		GetGameObject().GetComponentInChildren<Animation>().animation["Walk"].speed = 3;
	}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() {
		
		//print ( gameObject.tag + " is chasing" );
		
		if ( GetGameObject().GetComponent<Target>().GetTarget() != null )
		{
			
			
			// Get a path for our creep
			if ( ! GetGameObject().GetComponent<Move>()._hasPath )
			{
				Debug.Log("Searching for path for creep");
				GetGameObject().GetComponent<Move>().FindPath( GetGameObject().GetComponent<Target>().GetTarget() );
				//GetGameObject().GetComponent<Move>()._hasPath = true;
			}
			
			// start animation.
			GetGameObject().GetComponentInChildren<Animation>().animation.Play( "Walk" );
			
			
			if ( GetGameObject().GetComponent<Attack>().InAttackRange() )
			{
				// remove our path so it can make new calculations next chase state
				GetGameObject().GetComponent<Move>()._hasPath = false;
				
				// stop walk animation
				GetGameObject().GetComponentInChildren<Animation>().animation[ "Walk" ].time = 0;
				GetGameObject().GetComponentInChildren<Animation>().animation.Stop ( "Walk" );
				GetGameObject().GetComponent<CreepStateManager>().ChangeState( new AIStateCreepAttack( GetGameObject() ) );
				
			}
		} else {
			// remove our path so it can make new calculations next chase state
			GetGameObject().GetComponent<Move>()._hasPath = false;
			// stop walk animation
			GetGameObject().GetComponentInChildren<Animation>().animation[ "Walk" ].time = 0;
			GetGameObject().GetComponentInChildren<Animation>().animation.Stop ( "Walk" );
			GetGameObject().GetComponent<CreepStateManager>().ChangeState ( new AIStateCreepIdle( GetGameObject() ) );
			
		}
	}
}
