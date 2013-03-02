using UnityEngine;
using System.Collections;

public class BORRUDURRRR : MonoBehaviour {
	
	
	Plane plane;
	Ray ray;
	
	// Use this for initialization
	void Start () {
		plane = new Plane( Vector3.up, Vector3.zero );
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if ( Input.GetMouseButtonDown( 0 ) ) {
			print ( "mousedown!" );
			ray = Camera.mainCamera.ScreenPointToRay( Input.mousePosition );
			
			float enter = 0.0f;
			
			plane.Raycast( ray, out enter );
			
			Vector3 position = ray.origin + enter * ray.direction;
			
			
			int index = GameObject.Find( "Grid" ).GetComponent<GridScript>().DirGraph.GetClosestVertex( position );
			
			print ( "index = " + index );
			
			GameObject.Find( "Grid" ).GetComponent<GridScript>().DirGraph.vertices[index].ToggleTraversable();
			
		}
	}
}
