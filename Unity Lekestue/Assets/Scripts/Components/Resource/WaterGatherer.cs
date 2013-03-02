using UnityEngine;
using System.Collections;

public class WaterGatherer : MonoBehaviour {
	
	public int _gatheringSpeed = 2;
	public int _maxWaterGatherable = 100;
	private int _accumulatedWater;
	
	public int GatheringSpeed {
		set { _gatheringSpeed = value; }
		get { return _gatheringSpeed; }
	}
	public int AccumulatedWater {
		set
		{
			_accumulatedWater = value;
			if ( _accumulatedWater > _maxWaterGatherable )
				_accumulatedWater = _maxWaterGatherable;
			else if ( _accumulatedWater < 0 )
				_accumulatedWater = 0;
		}
		get { return _accumulatedWater; }
	}
	
	// use to get accumulated water and empty the harvester.
	public int DepleteWater()
	{
		int r = AccumulatedWater;
		AccumulatedWater = 0;
		return r;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
