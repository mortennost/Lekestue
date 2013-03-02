using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof ( Health ))]
[RequireComponent (typeof ( StructureScript ))]
public class StructureStateManager : StateManager {

	// Use this for initialization
	public new void Start () {
		SetStack( new Stack<State>() );
		
		PushState(new AIStateStructurePlacement( gameObject ) );
	}
}
