using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class CombatMovement : MonoBehaviour
{

	NavMeshAgent agent;
	public float MovementRange;
	public LayerMask Mask;
	public bool canMove;
	
	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{

		//whileloop enumratoriin tää paska
		if (canMove)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;


			if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			{

				if (Physics.Raycast(ray, out hit, Mathf.Infinity, Mask))
				{
					float dist = Vector3.Distance(hit.point, transform.position);
					Debug.Log("CombatMovement > " + this.name + "distance is: " + dist + ", and movement range is " + MovementRange);
					if (dist <= MovementRange)
					{

						StartCoroutine(Move(hit.point));

					}
				}
			}
		}

	}


	IEnumerator Move(Vector3 target)
	{
		var path = new NavMeshPath();
		agent.CalculatePath(target, path);
		yield return new WaitUntil(() => path.status == NavMeshPathStatus.PathComplete);
		agent.SetPath(path);
		canMove = false;
	}
}
