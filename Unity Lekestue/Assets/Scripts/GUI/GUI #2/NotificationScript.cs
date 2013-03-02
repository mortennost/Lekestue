using UnityEngine;
using System.Collections;

public class NotificationScript : MonoBehaviour {
	
	float timeDisplayed = 0.0f;
	string message;
	float timeToDisplay = 3.0f;
	bool displayMessage = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(displayMessage)
		{
			UpdateMessage();
		}
	}
	
	public void ShowMessage(string text)
	{
		displayMessage = true;
		message = text;
	}
	
	public void UpdateMessage()
	{
		if(timeDisplayed < timeToDisplay)
		{
			timeDisplayed += Time.deltaTime;
			Debug.Log(timeDisplayed);
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._lblNotification.enabled = true;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._lblNotification.label.text = "  " + message;
		}
		else
		{
			displayMessage = false;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._lblNotification.enabled = false;
			timeDisplayed = 0.0f;
		}
	}
}
