using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour 
{
	private int _result;
	private int _externalResult;
	private int _internalResult;
	private bool _calculated;
	
	public int firstNumber;
	public int secondNumber;
	public Color color;
	
	// Use this for initialization
	void Start () 
	{
		gameObject.renderer.material.color = color;
		_internalResult = firstNumber * secondNumber;
		_externalResult = _internalResult;
		_calculated = false;
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(!_calculated)
		{
			gameObject.tag = "";
			Calculate();
			gameObject.tag = "Box";
			_calculated = true;
		}
		
		// Check for input, then raycast
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			iGUI.iGUIContainer gui = GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().containerGUI;
			
			// Array of boxes in scene
			GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
			
			// Cast a ray and check what box we hit
			if(Physics.Raycast(ray, out hit, 100))
			{
				foreach(GameObject box in boxes)
				{
					// If the element hit is the same as the box currently "in" the loop
					if(hit.collider == box.collider)
					{
						box.transform.FindChild("Result").gameObject.SetActive(false);
						
						// Enable the GUI, set it's new position and update values
						Vector2 pos = new Vector2(Camera.main.WorldToScreenPoint(box.transform.position).x - (gui.rect.width / 2.0f), Screen.height - Camera.main.WorldToScreenPoint(box.transform.position).y - (gui.rect.height / 2.0f));
						GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().containerGUI.enabled = true;
						GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().containerGUI.setPosition(pos);
						
						GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().lblResult.label.text = "" + box.GetComponent<BoxScript>().GetExternalResult();
						GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().lblFirstNumber.label.text = "" + box.GetComponent<BoxScript>().firstNumber;
						GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().lblSecondNumber.label.text = "" + box.GetComponent<BoxScript>().secondNumber;
					}
					else
					{
						// Show result-value of the other boxes
						box.transform.FindChild("Result").gameObject.SetActive(true);
						box.transform.FindChild("Result").GetComponent<TextMesh>().text = "" + box.GetComponent<BoxScript>().GetExternalResult();
					}
				}
			}
			else
			{
				//Debug.Log("MISS!");
				
				// Disable Result-value/child when no boxes are hit by raycast
				foreach(GameObject box in boxes)
				{
					box.transform.FindChild("Result").gameObject.SetActive(false);
				}
				
				GameObject.Find("GUI").GetComponent<iGUICode_BoxScene>().containerGUI.enabled = false;
			}
		}
	}
	
	// Calculate external result by adding other boxes' values
	void Calculate()
	{
		GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
		
		foreach(GameObject box in boxes)
		{
			_externalResult += box.GetComponent<BoxScript>().GetExternalResult();
		}
	}
	
	// Return Box's Internal Result (firstNum * secondNum)
	public int GetInternalResult()
	{
		return _internalResult;
	}
	
	// Return Box's External Result (internal added with other boxes' values)
	public int GetExternalResult()
	{
		return _externalResult;
	}
}
