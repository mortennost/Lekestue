using UnityEngine;
using System.Collections;


[RequireComponent (typeof ( TutorialInputLayer ))]
[RequireComponent (typeof ( PlayInputLayer ))]
[RequireComponent (typeof ( BuildInputLayer ))]
[RequireComponent (typeof ( MenuInputLayer ))]
[RequireComponent (typeof ( GlobalInputLayer ))]

public class InputHandler : MonoBehaviour {
	
	InputLayer currentInputLayer;
	
	TutorialInputLayer tutorialInputLayer;
	PlayInputLayer playInputLayer;
	BuildInputLayer buildInputLayer;
	MenuInputLayer menuInputLayer;
	GlobalInputLayer globalInputLayer;

	// Use this for initialization
	void Start () {
		
		tutorialInputLayer = gameObject.GetComponent<TutorialInputLayer>();
		tutorialInputLayer = tutorialInputLayer == null ? gameObject.AddComponent<TutorialInputLayer>() : tutorialInputLayer;
		
		playInputLayer = gameObject.GetComponent<PlayInputLayer>();
		playInputLayer = playInputLayer == null ? gameObject.AddComponent<PlayInputLayer>() : playInputLayer;
		
		buildInputLayer = gameObject.GetComponent<BuildInputLayer>();
		buildInputLayer = buildInputLayer == null ? gameObject.AddComponent<BuildInputLayer>() : buildInputLayer;
		
		menuInputLayer = gameObject.GetComponent<MenuInputLayer>();
		menuInputLayer = menuInputLayer == null ? gameObject.AddComponent<MenuInputLayer>() : menuInputLayer;
		
		globalInputLayer = gameObject.GetComponent<GlobalInputLayer>();
		globalInputLayer = globalInputLayer == null ? gameObject.AddComponent<GlobalInputLayer>() : globalInputLayer;
		
		tutorialInputLayer.Disable();
		playInputLayer.Disable();
		menuInputLayer.Disable();
		buildInputLayer.Disable();
		
		SwitchToPlayInputLayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SwitchToTutorialInputLayer() {
		
		Debug.Log(gameObject.name + " - Switched to Tutorial input layer.");
		
		if (currentInputLayer != null) {
			currentInputLayer.Disable();
		}
		
		currentInputLayer = tutorialInputLayer;
		currentInputLayer.Enable();
	}
	
	public void SwitchToPlayInputLayer() {
		
		Debug.Log(gameObject.name + " - Switched to Play input layer.");
		
		if (currentInputLayer != null) {
			currentInputLayer.Disable();
		}
		
		currentInputLayer = playInputLayer;
		currentInputLayer.Enable();
	}
	
	public void SwitchToBuildInputLayer() {
		
		Debug.Log(gameObject.name + " - Switched to Build input layer.");
		
		if (currentInputLayer != null) {
			currentInputLayer.Disable();
		}
		
		currentInputLayer = buildInputLayer;
		currentInputLayer.Enable();
	}
	
	public void SwitchToMenuInputLayer() {
		
		Debug.Log(gameObject.name + " - Switched to Menu input layer.");
		
		if (currentInputLayer != null) {
			currentInputLayer.Disable();
		}
		
		currentInputLayer = menuInputLayer;
		currentInputLayer.Enable();
	}
	
	public void SwitchToGlobalInputLayer() {
		
		Debug.Log(gameObject.name + " - Switched to Global input layer.");
		
		if (currentInputLayer != null) {
			currentInputLayer.Disable();
		}
		
		currentInputLayer = globalInputLayer;
		currentInputLayer.Enable();
	}
}
