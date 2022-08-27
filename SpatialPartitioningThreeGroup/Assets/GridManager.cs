using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public static GridManager instance;

	[Range(10,50)]
  public int gridSize;

	[Range(1,100)]
	public int gridCellSize;

  [SerializeField] private GameObject gridCellPrefab;

	public GridCell[,] gridCellArray;

	private void Awake()
	{
		instance = this;

		GenerateGrid();

	}



	private void GenerateGrid()
	{

		gridCellArray = new GridCell[gridSize,gridSize];

		for(int x = 0; x < gridSize; x++)
		{
			for(int y = 0; y < gridSize; y++)
			{
				Vector3 cellPos = new Vector3(x, 0, y) * gridCellSize;

				GameObject cellInstance = Instantiate(gridCellPrefab,transform);

				cellInstance.name = "CellInstance" + x + y;

				cellInstance.transform.localScale = Vector3.one * gridCellSize;

				cellInstance.transform.position = cellPos;

				print(x + " " + y);

				gridCellArray[x, y] = cellInstance.GetComponent<GridCell>();
			}
		}
	}
}
