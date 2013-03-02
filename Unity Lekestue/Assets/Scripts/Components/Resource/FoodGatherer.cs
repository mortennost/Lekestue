using UnityEngine;
using System.Collections;

public class FoodGatherer : MonoBehaviour {
	
	public int _gatheringSpeedPerSecond = 2;
	public int _maxFoodGatherable = 10;
	private int _accumulatedFood;
	
	
	public int GatheringSpeed {
		set { _gatheringSpeedPerSecond = value; }
		get { return _gatheringSpeedPerSecond; }
	}
	public int AccumulatedFood {
		set
		{
			_accumulatedFood = value;
			if ( _accumulatedFood > _maxFoodGatherable )
				_accumulatedFood = _maxFoodGatherable;
			else if ( _accumulatedFood < 0 )
				_accumulatedFood = 0;
		}
		get { return _accumulatedFood; }
	}
	
	// use to get accumulated food and empty the harvester.
	public int DepleteFood()
	{
		int r = AccumulatedFood;
		AccumulatedFood = 0;
		return r;
	}
	
	// Use this for initialization
	void Start () {
		_accumulatedFood = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
