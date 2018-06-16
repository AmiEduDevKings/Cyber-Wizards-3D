using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CombatMovement : MonoBehaviour
{

    NavMeshAgent agent;
    public float MovementRange;
    public LayerMask Mask;
    public bool canMove;
    public int Damage = 10;

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
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

                    if (dist <= MovementRange)
                    {

                        StartCoroutine(Move(hit.point));

                    }
                }
            }
        }

    }


    public void CanMove()
    {
        canMove = true;
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
