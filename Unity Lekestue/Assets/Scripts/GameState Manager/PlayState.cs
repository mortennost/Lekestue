using UnityEngine;
using System.Collections;

public class PlayState : State
{
	public PlayState(GameObject gameObject)
		: base(gameObject)
	{
	}
	
	public override void OnStart()
	{
		// Switch to PlayInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToPlayInputLayer();
		
		// Release camera target
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
	
	public override void OnPause()
	{
	}
	
	public override void OnExecute()
	{
	}
	
	public override void OnContinue()
	{
		// Switch to PlayInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToPlayInputLayer();
		
		// Release camera target
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
	
	public override void OnStop()
	{
	}
}

