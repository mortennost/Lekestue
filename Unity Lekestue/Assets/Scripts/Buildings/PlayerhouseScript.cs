using UnityEngine;
using System.Collections;

public class PlayerhouseScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{		
		// Set GridSnapper size
		GameObject.Find("Gridsnapper").GetComponent<GridsnapperScript>().xSize = GetComponent<StructureScript>().xSize;
		GameObject.Find("Gridsnapper").GetComponent<GridsnapperScript>().zSize = GetComponent<StructureScript>().zSize;
		
		GameObject.Find("Gridsnapper").transform.position = GameObject.Find("Grid").GetComponent<GridScript>().GetCenter();
		GameObject.Find("Gridsnapper").GetComponent<GridsnapperScript>().Snap();
		
		transform.position = GameObject.Find("Gridsnapper").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
