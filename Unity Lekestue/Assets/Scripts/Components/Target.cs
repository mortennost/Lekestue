using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	GameObject _target;
	// Use this for initialization
	void Start () {
		_target = null;
		
		print ( "this objects tag is: " + gameObject.tag );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject GetTarget() { return _target; }
	public void SetTarget( GameObject t ) { _target = t; }
	
	public GameObject FindNearestTarget( string tag ){ 
		
		
		GameObject[] structures = GameObject.FindGameObjectsWithTag( tag );
		
		GameObject nearestStructure = null;
		
		float currentMinDist = Mathf.Infinity;
		
		foreach( GameObject structure in structures )
		{
			float distance = Vector3.Distance ( transform.position, structure.transform.position );
			
			if ( distance < currentMinDist )
			{
				nearestStructure = structure;
				currentMinDist = distance;
			}
			
		}
		
		return nearestStructure;
	}
	
	public void lookAtTarget() {
		
		gameObject.transform.LookAt( _target.transform.position );
		
	}
}
