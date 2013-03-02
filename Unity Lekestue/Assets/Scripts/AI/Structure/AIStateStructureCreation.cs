using UnityEngine;
using System.Collections;

public class AIStateStructureCreation : State {
	
	public int _buildSpeed = 10;
	private float _nextBuildFase = 0;

	public AIStateStructureCreation( GameObject gameObject ) : base( gameObject ) {
		
	}	
	
	public override void OnStart()
	{
		_nextBuildFase = Time.realtimeSinceStartup;
		GetGameObject().tag = "Structure";
		
		if(GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().GetWorkerCount() < GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().GetMaxWorkerCount())
		{
			GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().AddWorker();
		}
	}
	public override void OnPause() {}
	public override void OnContinue() {}
	public override void OnStop()
	{
		
	}
	
	public override void OnExecute() {
		
		if(GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().GetWorkerCount() <= GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().GetMaxWorkerCount())
		{
			// nextBuilFase
			if ( _nextBuildFase <= Time.realtimeSinceStartup ) 
			{
				// this is 1 second ahead in time. since this is called every second.
				_nextBuildFase += 1;
				GetGameObject().GetComponent<Health>().addHealth( _buildSpeed );
			
				if ( GetGameObject().GetComponent<Health>().getHealth() == GetGameObject().GetComponent<Health>().MaxHealth ) 
				{
					GetGameObject().GetComponent<StructureStateManager>().ChangeState ( new AIStateStructureOperational( GetGameObject() ) );
					GameObject.Find("ResourceManager").GetComponent<ResourceManagerScript>().RemoveWorker();
				}
			}
		}
		
		
		
	}	
}
