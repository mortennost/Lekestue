using UnityEngine;
using System.Collections;

public class AIStateTurretAttack : State {
	
	public AIStateTurretAttack( GameObject gameObject ) : base( gameObject ) {
		
	}	
	
	public override void OnStart()
	{
		
		//Set Speed of Attack Animation. 1/attackSpeed;
		GetGameObject().GetComponentInChildren<Animation>().animation["Attack"].speed = 1/
				GetGameObject().GetComponent<Attack>()._attackSpeed;
		
	}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() {
		
		
		// we dont want this to change target ie: go back to idle if it allready has a target;
		
		if ( GetGameObject().GetComponent<Target>().GetTarget() != null ) {
		// check if the target is in range and if attack is ready;
			if (GetGameObject().GetComponent<Attack>().InAttackRange() &&
				GetGameObject().GetComponent<Attack>().AttackReady() ) 
			{
				// attack
				
				//GetGameObject().GetComponentInChildren<Animator>().animation.GetClip( "Attack" ).averageSpeed = 1;
				// set look at target here, since it allways go here between getting new targets.
				GetGameObject().GetComponent<Target>().lookAtTarget();
				
				GetGameObject().GetComponentInChildren<Animation>().animation["Attack"].time = 0;
				
				GetGameObject().GetComponentInChildren<Animation>().animation.Play();
				
				GetGameObject().GetComponent<Attack>().DealDamage();
				//
			}
		}
		else
		{
			GetGameObject().GetComponent<TurretStateManager>().ChangeState ( new AIStateTurretIdle( GetGameObject() ) );
			
		}
	}	
}
