using UnityEngine;
using System.Collections;

public class SlowEffect : MonoBehaviour {
	
	public float _duration = 4;
	public float _slowPercentage = 0.5f;
	private float _initSpeed;
	private float _dur;

	// Use this for initialization
	void Start () {
		_initSpeed = gameObject.GetComponent<Move>().MovementSpeed;
		
		gameObject.GetComponent<Move>().MovementSpeed *= (1 - _slowPercentage );
		_dur = _duration;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		
		_dur -= Time.fixedDeltaTime;
		if ( _dur <= 0 ) {
			
			print ( "debuff done " );
			gameObject.GetComponent<Move>().MovementSpeed = _initSpeed;
			
			Destroy( this );
		}
	}
	
	public void ResetTimer() {
		_dur = _duration;
	}
}
