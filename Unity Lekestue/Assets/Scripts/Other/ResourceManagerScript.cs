using UnityEngine;
using System.Collections;

public class ResourceManagerScript : MonoBehaviour {
	
	int _foodCount;
	int _maxFoodCount;
	
	int _waterCount;
	int _maxWaterCount;
	
	int _scrapCount;
	int _maxScrapCount;
	
	int _workerCount;
	int _maxWorkerCount;
	
	int _currentExperience;
	int _maxExperience;
	int _currentLevel;
	int _maxLevel;
	
	// Use this for initialization
	void Start () 
	{
		_foodCount = 900;
		_maxFoodCount = 900;
		_waterCount = 900;
		_maxWaterCount = 900;
		_scrapCount = 100;
		_maxScrapCount = 100;
		
		_workerCount = 0;
		_maxWorkerCount = 2;
		
		_currentExperience = 500;
		_maxExperience = 1000;
		_currentLevel = 6;
		_maxLevel = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void AddFood(int food)
	{
		if(_foodCount < _maxFoodCount)
		{
			if(_foodCount + food > _maxFoodCount)
			{
				_foodCount = _maxFoodCount;
			}
			else
			{
				_foodCount += food;
			}
		}
	}
	
	public void DepleteFood(int food)
	{
		_foodCount -= food;
	}
	
	public void SetMaxFoodCount(int maxFood)
	{
		_maxFoodCount = maxFood;
	}
	
	public int GetFood()
	{
		return _foodCount;
	}
	
	public int GetMaxFood()
	{
		return _maxFoodCount;
	}
	
	public void AddWater(int water)
	{
		if(_waterCount < _maxWaterCount)
		{
			if(_waterCount + water > _maxWaterCount)
			{
				_waterCount = _maxWaterCount;
			}
			else
			{
				_waterCount += water;
			}
		}
	}
	
	public void DepleteWater(int water)
	{
		_waterCount -= water;
	}
	
	public void SetMaxWaterCount(int maxWater)
	{
		_maxWaterCount = maxWater;
	}
	
	public int GetWater()
	{
		return _waterCount;
	}
	
	public int GetMaxWater()
	{
		return _maxWaterCount;
	}
	
	public void AddScrap(int scrap)
	{
		if(_scrapCount < _maxScrapCount)
		{
			if(_scrapCount + scrap > _maxScrapCount)
			{
				_scrapCount = _maxScrapCount;
			}
			else
			{
				_scrapCount += scrap;
			}
		}
	}
	
	public void DepleteScrap(int scrap)
	{
		_scrapCount -= scrap;
	}
	
	public void SetMaxScrapCount(int maxScrap)
	{
		_maxScrapCount = maxScrap;
	}
	
	public int GetScrap()
	{
		return _scrapCount;
	}
	
	public int GetMaxScrap()
	{
		return _maxScrapCount;
	}
	
	public void AddWorker()
	{
		_workerCount++;
	}
	
	public void RemoveWorker()
	{
		_workerCount--;
	}
	
	public void SetMaxWorkerCount(int maxWorkers)
	{
		_maxWorkerCount = maxWorkers;
	}
	
	public int GetWorkerCount()
	{
		return _workerCount;
	}
	
	public int GetMaxWorkerCount()
	{
		return _maxWorkerCount;
	}
	
	public int GetExperience()
	{
		return _currentExperience;
	}
	
	public int GetMaxExperience()
	{
		return _maxExperience;
	}
	
	public int GetLevel()
	{
		return _currentLevel;
	}
	
	public int GetMaxLevel()
	{
		return _maxLevel;
	}
}
