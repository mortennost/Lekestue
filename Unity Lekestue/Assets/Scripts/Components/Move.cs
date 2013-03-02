using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;

public class Move : MonoBehaviour {
	
	//private Vector3 _direction;
	public float _movementSpeed = 15;
	public bool _hasPath;
	
	//private static DirectedGraph _graph;
	private List<Vector3> _movementPath;
	private int _currentStep;
	private float _margin = 0.5f;
	private GridScript _gridScript;
	private int _endNode;
	private float _durrTimer;
	
	private Vector3 _finalDirection;
	
	public float MovementSpeed
	{
		get { return _movementSpeed; }
		set { _movementSpeed = value; }
	}
	
	// Use this for initialization
	void Start () {
		
		_durrTimer = 0.0f;
		_gridScript = GameObject.Find( "Grid" ).GetComponent<GridScript>();
		
		_currentStep = 0;
		_hasPath = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		//print ("Current movementspeed: " + MovementSpeed );
		if ( _hasPath ) {
			
			
			for ( int i = 0; i < _movementPath.Count - 1; ++i ) {
				Debug.DrawLine( _movementPath[i], _movementPath[ i + 1 ], Color.red );
			}
			
			// check if we have done our step. and increment it if we have :>
			if ( (Vector3.SqrMagnitude(_movementPath[ _currentStep ] - transform.position ) <= _margin ) &&
				 ( _currentStep < _movementPath.Count - 1 ) )
			{
				
				++_currentStep;
				Debug.Log( "step is: " + _currentStep );
				_finalDirection = Vector3.Normalize( _movementPath[ _currentStep ] - transform.position );
			}
			
			updateHeading();
			updatePosition();
			
		} else {
			
			
			
		}
	}
	
	public void applyForce( Vector3 force )
	{
		
		
		
	}
	
	public void updateHeading()
	{
		
		//transform.forward = Vector3.Normalize( _finalDirection ); 
		
		
		if ( transform.forward != _finalDirection ) {
			print( "updating transform.forward" );
			_durrTimer += 0.02f;
			if ( _durrTimer > 1.0f )
				_durrTimer = 1.0f;
			
			transform.forward = Vector3.Normalize( Vector3.Lerp( transform.forward,
								_finalDirection,
								_durrTimer ) );
			
			
		} else {
			print ( "its should be right now o0" );
			_durrTimer = 0;
		}
		
	}
	
	public void FindPath( GameObject target ) {
		
		// have to find which node of the target is the shortest path;
		// first find a unit vector giving us the direction from the target to our creep
		
		Vector3 unit = Vector3.Normalize( transform.position - target.transform.position );
		
		// now we have to find wich ratio we will multiply x and z of the unit vector with for
		// odd shapes.
		float xRatio = target.GetComponent<StructureScript>().xSize / 2;
		float zRatio = target.GetComponent<StructureScript>().zSize / 2;
		
		unit.x *= xRatio;
		unit.z *= zRatio;
		
		// now we have distorted the unit vector and we need to add this vector to the targets
		// position to get the final position of our node.
		
		Vector3 position = target.transform.position + unit;
		
		
		_movementPath = _gridScript.DirGraph.GetShortestPath( transform.position, position );
		
		if ( _movementPath.Count > 1 ) {
			
			_hasPath = true;
			_currentStep = 0;
			
			_endNode = _gridScript.DirGraph.GetClosestVertex( _movementPath[ _movementPath.Count - 1 ] );
			transform.forward = Vector3.Normalize( _movementPath[ _currentStep ] - transform.position );
			
		}
		print( "Steps to target: " + _movementPath.Count );
		
		
		
		
		// for normal movement:
		//transform.forward = position - gameObject.transform.position;
	
	}
	
	// translate according to direction vector.
	public void updatePosition() { 
		
		transform.Translate( Vector3.forward * _movementSpeed * Time.fixedDeltaTime );
		
	}
}
