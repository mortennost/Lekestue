using UnityEngine;
using System.Collections;
using iGUI;

public class iGUICode_BoxScene : MonoBehaviour
{
	[HideInInspector]
	public iGUIRoot root;
	[HideInInspector]
	public iGUIContainer containerGUI;
	[HideInInspector]
	public iGUIImage imgGUI;
	[HideInInspector]
	public iGUILabel lblResult;
	[HideInInspector]
	public iGUILabel lblFirstNumber;
	[HideInInspector]
	public iGUILabel lblSecondNumber;
	[HideInInspector]
	public iGUILabel lblX;
	

	static iGUICode_BoxScene instance;
	
	void Awake()
	{
		instance=this;
	}
	
	public static iGUICode_BoxScene getInstance()
	{
		return instance;
	}

}
