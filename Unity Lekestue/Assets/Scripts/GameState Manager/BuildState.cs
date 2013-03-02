using UnityEngine;
using System.Collections;

public class BuildState : State
{
	public BuildState(GameObject gameObject)
		: base(gameObject)
	{
	}
	
	public override void OnStart()
	{
		// Switch to BuildInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToBuildInputLayer();
		
		// Set the Gridsnapper to center of Grid
		//GameObject.Find("Gridsnapper").transform.position = GameObject.Find("Grid").GetComponent<GridScript>().GetCenter();
		
		// Set camera target to the gridsnapper
		Camera.mainCamera.GetComponent<CameraScript>().target = GameObject.Find("Gridsnapper");
		
		GameObject.Find("ConstructionHighlight Z").renderer.enabled = true;
		GameObject.Find("ConstructionHighlight X").renderer.enabled = true;
	}
	
	public override void OnPause()
	{
		GameObject.Find("ConstructionHighlight Z").renderer.enabled = false;
		GameObject.Find("ConstructionHighlight X").renderer.enabled = false;
		
		// Release camera target
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
	
	public override void OnExecute()
	{
	}
	
	public override void OnContinue()
	{
		GameObject.Find("ConstructionHighlight Z").renderer.enabled = true;
		GameObject.Find("ConstructionHighlight X").renderer.enabled = true;
		
		// Switch to BuildInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToBuildInputLayer();
		
		// Set camera target to the gridsnapper
		Camera.mainCamera.GetComponent<CameraScript>().target = GameObject.Find("Gridsnapper");
	}
	
	public override void OnStop()
	{
		GameObject.Find("ConstructionHighlight Z").renderer.enabled = false;
		GameObject.Find("ConstructionHighlight X").renderer.enabled = false;
		
		// Release camera target
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
}

