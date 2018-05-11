using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	public class Popup : MonoBehaviour
	{

		public float life;
		public GameObject Target { get; set; }

		// Use this for initialization
		void Start()
		{
			if (life > 0f)
			{
				Destroy(gameObject, life);
			}
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			if (Target)
				transform.position = Camera.main.WorldToScreenPoint(Target.transform.position);
		}
	}
}