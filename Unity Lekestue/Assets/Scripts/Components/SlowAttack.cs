using UnityEngine;
using System.Collections;

[RequireComponent (typeof ( Attack ))]
public class SlowAttack : MonoBehaviour {
	
	public float _slowPercentage = 0.1f;
	public float _duration;
	// Use this for initialization

	public float GetMovementModifier() {
		return 1 - _slowPercentage;
	}
	
}
