using UnityEngine;
using System.Collections;

public class RotateDiscoBall : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		iTween.RotateBy(gameObject, new Vector3(0.01f, 0.01f, 0.01f), 0.01f);
	}
}
