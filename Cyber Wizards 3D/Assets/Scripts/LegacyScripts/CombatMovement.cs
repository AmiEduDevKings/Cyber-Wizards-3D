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
    public Animator anim;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {

        //whileloop enumratoriin tää paska
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {

                Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit interactionInfo;
                if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
                {
                    agent.stoppingDistance = 0f;
                    agent.destination = interactionInfo.point;
                    anim.SetBool("Walking", true);
                    canMove = false;
                    
                    Debug.Log("liikuit combatissa");
                }
            }
        }


    }


    public void CanMove()
    {
        Debug.Log("combat move can move: " + name);
        canMove = true;
    }

    public void CantMove() {
        canMove = false;
    }

  
}
