using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof ( Target ))]
public class Attack : MonoBehaviour {
	
	public float _attackRange = 20;
	public int _attackDamage = 5;
	public float _attackSpeed = 1;
	
	private float _lastAttack;
	
	// Use this for initialization
	void Start () {
		
		_lastAttack = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// checks if attack delay is present or not.
	public bool AttackReady() {
		
		if ( _lastAttack <= Time.realtimeSinceStartup )
		{
			_lastAttack = _attackSpeed + Time.realtimeSinceStartup;
			//print ( gameObject.tag + "Attack ready" );
			return true;
		}
		//print ( gameObject.tag + " Attack Not ready" );
		return false;
	}
	
	// check if target is in attack range.
	public bool InAttackRange() {
		
		GameObject target = GetComponent<Target>().GetTarget();
		
		if ( target == null )
		{
			print ( gameObject.tag + " Error: no target" );
			return false;
		}
		
		float distance = Vector3.Distance( transform.position, target.transform.position );
		
		// using sqrMagnitude since its faster than taking the squareroot, then Pow(x, 2 ) on rest.
		if ( distance <= _attackRange )
			return true;
		
		//print ( gameObject.tag + " not in " + _attackRange + " m range" );
		return false;
	}
	
	
	// deals damage to target and checks for AOE, Slow and Crit
	// bool in case we have to check if it actually happened.

	public void DealDamage() {
		
		GameObject target = GetComponent<Target>().GetTarget ();
		
		if ( target != null )
		{
			//ArrayList<GameObject> targets = new ArrayList<GameObject>();
			//GameObject[] targets = new GameObject[100];
			List<GameObject> targets = new List<GameObject>();
			
			float damage = _attackDamage;
			
			if ( GetComponent<AOEAttack>() )
			{
				GameObject[] tempTargets = GameObject.FindGameObjectsWithTag( target.tag );
				//targets = new GameObject[tempTargets.Length];
				foreach ( GameObject t in tempTargets )
				{
					// calculate distance between all the found objects and our primary target
					float tempDist = Vector3.Distance ( target.transform.position, t.transform.position );
					// if within distance put it in our array;
					if ( tempDist <= GetComponent<AOEAttack>().Radius )
					{
						targets.Add( t );
					}
					//print( "found " + targets. + " targets" );
				}
			} else {
				// theres no AOE attack, so only our primary target to put in our targets array :>
				targets.Add( target );
				//targets[0] = target;
			}
			
			
			// Now iterate trough our targets array and deal damage;
			foreach ( GameObject t in targets )
			{
				//print( "current iteration tag " + t.tag );
				// check if this attack slows
				if ( GetComponent<SlowAttack>() )
				{
					// check if target is already slowed; if it is, then reset slow timer;
					if ( t.GetComponent<SlowEffect>() )
						t.GetComponent<SlowEffect>().ResetTimer();
					else
						t.AddComponent<SlowEffect>();
					
					//print ( "checked for slow effect" );
				}
				
				if ( GetComponent<CriticalAttack>() && GetComponent<CriticalAttack>().Crit() )
				{
					damage *= GetComponent<CriticalAttack>().CritMultiplier;
					print ( "it crit" );
				}
				
				t.GetComponent<Health>().RemoveHealth( (int)damage );
				//GetComponent<Target>().GetTarget().GetComponent<Health>().RemoveHealth( (int)damage );
				
			}
			
			//GetComponent<Target>().GetTarget ().GetComponent<Health>().RemoveHealth( (int)_attackDamage );
		
		}
		
	}
}
