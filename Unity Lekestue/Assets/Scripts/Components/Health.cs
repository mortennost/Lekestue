using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int _maxHealth = 100;
	public int _health;
	
	public int CurHealth {
		set { _health = value; }
		get { return _health; }
	}
	
	public int MaxHealth {
		set { _maxHealth = value; }
		get { return _maxHealth; }
	}

	// Use this for initialization
	void Start () {
		
		if ( GetComponent<StructureStateManager>() )
			_health = 0;
		else
			_health = _maxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
	}
	
	public int getHealth() { return _health; }
	public void addHealth( int health )
	{
		if ( ( _health + health ) > MaxHealth )
		{
			_health = MaxHealth;
		} else {
			_health += health;
		}
		
		//print( gameObject.tag + " health: " + _health );
	}
	public void RemoveHealth( int health ) {
		_health -= health; 
		//print( gameObject.tag + " health: " + _health );
		
		if ( _health <= 0 ) IsDead ();
	}
	
	void IsDead() {
		
		Destroy( gameObject );
		
		
	}
	
	// removehealth by percentage();
	// 
}
