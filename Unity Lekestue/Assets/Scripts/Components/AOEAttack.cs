using UnityEngine;
using System.Collections;

[RequireComponent (typeof ( Attack ))]
public class AOEAttack : MonoBehaviour {
	
	public float _radius;
	
	public float Radius {
		get { return _radius; }
		set { _radius = value; }
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
