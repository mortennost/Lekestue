using UnityEngine;
using System.Collections;

public class GatheringManager : MonoBehaviour {

	// Use this for initialization
	
	private float _nextHarvestTime;
	private bool _skippedFirst = false;
	
	private FoodGatherer fg;
	private WaterGatherer wg;
	
	void Start () {
		_nextHarvestTime = Time.realtimeSinceStartup;
		
		if ( GetComponent<FoodGatherer>() ) {
			fg = GetComponent<FoodGatherer>();
		} else if ( GetComponent<WaterGatherer>() ) {
			wg = GetComponent<WaterGatherer>();
		} else {
			print ( "You have not assigned a water- or food gatherer to this object" );
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		
		// skippedFirst is used to let structurestatemanager initialize so we dont get an error when checking the stack.
		if ( _skippedFirst ) {
			if ( GetComponent<StructureStateManager>().GetPeek().ToString() == "AIStateStructureOperational" ) {
				
				// check timer here to o.0 save resources? :>
				if ( _nextHarvestTime <= Time.realtimeSinceStartup ) {
					_nextHarvestTime = Time.realtimeSinceStartup + 1.0f;
				
					if ( fg ) {
						// this is a food gatherer :>
						
						fg.AccumulatedFood += fg.GatheringSpeed;
						//print ( "Food: " + fg.AccumulatedFood );
					} else if ( wg ) {
						
						// this is a Water gatherer :>
						
						wg.AccumulatedWater += wg.GatheringSpeed;
						//print ( "Water: " + wg.AccumulatedWater );
						
					} else {
						
						print ( "This harvester does not have a water or food component" );
					}
				}
			}
		} else {
			_skippedFirst = true;
			//print ( GetComponent<StructureStateManager>().GetPeek().ToString() );
		}
		
		
	}
}
