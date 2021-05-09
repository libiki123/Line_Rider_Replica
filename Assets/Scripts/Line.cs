using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	public float distanceBetweenPoint = 0.1f;

	private LineRenderer lineRenderer;
	private EdgeCollider2D edgeColl;

	private List<Vector2> points;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
		edgeColl = GetComponent<EdgeCollider2D>();
	}

	public void UpdateLine(Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List<Vector2>();											// make a new list when first create
			SetPoint(mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > distanceBetweenPoint)       // Check if mouse distance is enough to draw a new point
		{
			SetPoint(mousePos);
		}

	}

	private void SetPoint(Vector2 point)
	{
		points.Add(point);

		lineRenderer.positionCount = points.Count;                  // + one more point
		lineRenderer.SetPosition(points.Count - 1, point);          // draw line from previous last point (index = points.Count - 1) to new point

		if (points.Count > 1)                                       // ensure there is at least 2 points
			edgeColl.points = points.ToArray();                     // set collider to new point
	}

}
