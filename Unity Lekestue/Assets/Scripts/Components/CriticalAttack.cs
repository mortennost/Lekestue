using UnityEngine;
using System.Collections;

[RequireComponent (typeof ( Attack ))]
public class CriticalAttack : MonoBehaviour {
	
	public float _critChance = 0.10f;
	public float _critMultiplier = 1.5f;
	
	public float CritChance
	{
		get { return _critChance; }
		set { _critChance = value; }
	}
	public float CritMultiplier
	{
		get { return _critMultiplier; }
		set { _critMultiplier = value; }
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/* return true if its a critical hit.*/
	public bool Crit() {
		
		if ( Random.value <= CritChance )
		{
			return true;
		}
		return false;
	}
}
