using UnityEngine;
using System.Collections;
using iGUI;

public class DestroyStructureAction : iGUIAction {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void act (iGUIElement caller)
	{
		Camera.mainCamera.GetComponent<CameraScript>().target = null;
	}
}
