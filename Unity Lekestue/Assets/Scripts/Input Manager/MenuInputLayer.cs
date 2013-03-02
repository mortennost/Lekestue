using UnityEngine;
using System.Collections;

public class MenuInputLayer : InputLayer
{
	
	InputHandler inputHandler;

	// Use this for initialization
	void Start ()
	{
		inputHandler = gameObject.GetComponent<InputHandler>();
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
