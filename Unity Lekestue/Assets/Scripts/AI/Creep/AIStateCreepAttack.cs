using UnityEngine;
using System.Collections;

public class AIStateCreepAttack : State {
	
	public AIStateCreepAttack( GameObject gameObject ) : base( gameObject ) {
		
	}
	
	public override void OnStart() {}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop() {}
	
	public override void OnExecute() {
		
		if ( GetGameObject().GetComponent<Target>().GetTarget() != null )
		{
			
			Attack attackComp = GetGameObject().GetComponent<Attack>();
		
			if ( attackComp.InAttackRange() )
			{
				if ( attackComp.AttackReady() )
				{
					attackComp.DealDamage();
				}
			} 
		} else {
				
			GetGameObject().GetComponent<CreepStateManager>().ChangeState( new AIStateCreepIdle( GetGameObject() ) );
		}
	}	
}