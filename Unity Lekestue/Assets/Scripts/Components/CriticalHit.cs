using UnityEngine;
using System.Collections;

[RequireComponent (typeof ( Attack ))]
public class CriticalHit : MonoBehaviour {
	
	public float _critChance = 0.10f;
	public float _critMultiplier = 1.5f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/* return true if its a critical hit.*/
	public bool Crit() {
		
		if ( Random.value <= _critChance )
		{
			return true;
		}
		return false;
	}
}
