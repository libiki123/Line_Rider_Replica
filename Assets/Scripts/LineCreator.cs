using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
	[SerializeField] private GameObject linePrefab;

	Line activeLine;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject lineGO = Instantiate(linePrefab);
			activeLine = lineGO.GetComponent<Line>();
		}

		if (Input.GetMouseButtonUp(0))
		{
			activeLine = null;
		}

		if (activeLine != null)
		{
			Vector3 mouse = Input.mousePosition;
			mouse.z = 10;
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouse);
			activeLine.UpdateLine(mousePos);
		}

	}

	public void PickLineType(GameObject lineType)		// called in Button onlick() event
	{
		linePrefab = lineType;
	}
}
