using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof ( Target ))]
[RequireComponent (typeof ( Move ))]
[RequireComponent (typeof ( Attack ))]
[RequireComponent (typeof ( Health ))]
public class CreepStateManager : StateManager {

	// Use this for initialization
	public new void Start () {
		SetStack( new Stack<State>() );
		
		PushState(new AIStateCreepIdle( gameObject ) );
	}
}
