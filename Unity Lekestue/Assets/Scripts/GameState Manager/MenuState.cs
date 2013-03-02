using UnityEngine;
using System.Collections;

public class MenuState : State
{
	public MenuState(GameObject gameObject)
		: base(gameObject)
	{
	}
	
	public override void OnStart()
	{
		// Switch to MenuInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToMenuInputLayer();
		
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
		// Switch to MenuInputLayer
		GameObject.Find("Input Manager").GetComponent<InputHandler>().SwitchToMenuInputLayer();
		
		// Release camera target
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
	
	public override void OnStop()
	{
	}
}

