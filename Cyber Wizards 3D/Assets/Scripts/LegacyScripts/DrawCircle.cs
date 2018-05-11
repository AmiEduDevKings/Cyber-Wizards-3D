﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	[RequireComponent(typeof(LineRenderer))]
	public class DrawCircle : MonoBehaviour
	{

		[Range(0, 50)]
		public int segments = 50;

		public float xradius { get; set; }
		public float yradius { get; set; }

		LineRenderer line;


		void Start()
		{
			line = gameObject.GetComponent<LineRenderer>();
			line.positionCount = segments + 1;
			line.useWorldSpace = false;
		}

		public void CreatePoints()
		{
			line.positionCount = segments + 1;
			float x;
			//float y;
			float z;

			float angle = 20f;

			for (int i = 0; i < (segments + 1); i++)
			{
				x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
				z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;
				line.SetPosition(i, new Vector3(x, -0.5f, z));

				angle += (360f / segments);
			}
		}

		public void RemovePoints()
		{
			line.positionCount = 0;
		}
	}
}