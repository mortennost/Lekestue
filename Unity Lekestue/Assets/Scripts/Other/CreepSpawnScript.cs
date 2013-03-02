using UnityEngine;
using System.Collections;

public class CreepSpawnScript : MonoBehaviour {
	
	public Transform _creep;
	
	private int _counter = 0;
	
	public void SpawnCreep()
	{
		Vector3 pos = transform.position;
		
		switch(_counter)
		{
		case 0:
			pos.x = 0.0f;
			break;
		case 1:
			pos.x = 15.0f;
			break;
		case 2:
			pos.x = 30.0f;
			break;
		default:
			pos.x = 0.0f;
			break;
		}
		
		Instantiate(_creep, pos, Quaternion.identity);
		
		if(_counter == 2)
		{
			_counter = 0;
		}
		else
		{
			_counter++;
		}
	}
}
