using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace legacyScripts
{
	[CreateAssetMenu(menuName = "RayCaster")]
	public class Raycaster : ScriptableObject
	{

		private Ray ray;
		private RaycastHit hit;

		public bool CheckHit(LayerMask mask)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			return Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
		}

		public bool CheckHit()
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			return Physics.Raycast(ray, out hit, Mathf.Infinity);
		}

		public RaycastHit GetHit()
		{
			return hit;
		}

		public GameObject GetObject()
		{
			return hit.collider.gameObject;
		}
	}
}