using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] private GameObject enemyPrefab;

	[Range(10,100)]
	[SerializeField] private int maxEnemyCount; 

	private void Start()
	{
		SpawnEnemies();
	}

	private void SpawnEnemies()
	{
		for(int i = 0; i < maxEnemyCount; i++)
		{

			float halfCellSize = (GridManager.instance.gridCellSize / 2);

			float gridLegth = GridManager.instance.gridCellSize * GridManager.instance.gridSize-halfCellSize;

			float randomXPos = Random.Range(-halfCellSize, gridLegth);

			float randomZPos= Random.Range(-halfCellSize, gridLegth);

			GameObject enemyInstance = Instantiate(enemyPrefab, transform);

			enemyInstance.transform.position = new Vector3(randomXPos, 0,randomZPos);

			int cellIndexColumn = (int)(randomXPos+halfCellSize) / GridManager.instance.gridCellSize;

			int cellIndexRow = (int)(randomZPos+halfCellSize) / GridManager.instance.gridCellSize;

			GridManager.instance.gridCellArray[cellIndexColumn, cellIndexRow].enemyList.Add(enemyInstance);
		}
	}
}
