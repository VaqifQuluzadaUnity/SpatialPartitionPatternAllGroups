using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask cellLayer;

	[SerializeField] private GridCell currentCell;

	private void Start()
	{
		InvokeRepeating("DetectCurrentCell",0,0.1f);
	}

	private void DetectCurrentCell()
	{
		Ray ray = new Ray(transform.position, -transform.up);

		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast(ray, out hit, 10,cellLayer))
		{
			currentCell = hit.collider.GetComponent<GridCell>();
		}
	}
    
}
