﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
	public Transform pointPrefab;
	[Range(10, 1000)]
	public int resolution = 10;

	Transform[] points;

	// Start is called before the first frame update
	void Awake()
    {
		float step = 2f / resolution;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;
		Vector3 scale = Vector3.one * step;

		points = new Transform[resolution];

		for (int i = 0; i < points.Length; i++)
		{
			Transform point = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f; 
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform,false);
			points[i] = point;
		}
	}

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
			point.localPosition = position;
		}
	}
}
