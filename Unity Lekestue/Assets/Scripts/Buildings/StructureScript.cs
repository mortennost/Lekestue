using UnityEngine;
using System.Collections;
using iGUI;

public class StructureScript : MonoBehaviour {
	
	public int xSize;
	public int zSize;
	
	public int buildCostWater;
	public int buildCostFood;
	public int buildCostScrap;
	
	public string subMenuSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool IsInsideBounds(Vector3 tapPosition)
	{
		float xMin = transform.position.x - xSize / 2.0f;
		float xMax = transform.position.x + xSize / 2.0f;
		float zMin = transform.position.z - zSize / 2.0f;
		float zMax = transform.position.z + zSize / 2.0f;
		
		if(tapPosition.x > xMin && tapPosition.x < xMax
			&& tapPosition.z > zMin && tapPosition.z < zMax)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void OpenSubMenu(GameObject obj)
	{
		if(subMenuSystem == "Harvester")
		{
			iGUIButton btnDestroy = GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure;
			iGUIButton btnHarvest = GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnHarvest;
			btnDestroy.enabled = true;
			btnHarvest.enabled = true;
			
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.opacity = 0.0f;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnHarvest.opacity = 0.0f;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.fadeTo(1.0f, 0.2f);
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnHarvest.fadeTo(1.0f, 0.2f);
			
			GameObject.Find("11-Harvest Button").GetComponent<HarvestAction>().obj = obj;
		}
		else
		{
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.opacity = 0.0f;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.enabled = true;
			GameObject.Find("GUI").GetComponent<iGUICode_GUI_mockup2>()._btnDestroyStructure.fadeTo(1.0f, 0.2f);
		}
	}
}
