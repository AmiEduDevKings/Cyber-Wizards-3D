using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantAI : MonoBehaviour {

    
    public GameEvent OnTurnChanged;

    public bool moving = false;
    private NavMeshAgent agent;
    public float movementRange;
    
    public GameObject target;
    public int Damage;
    public float HittingDistance;

    // Use this for initialization
	void Start () {
        
        agent = gameObject.GetComponent<NavMeshAgent>();
        movementRange = gameObject.GetComponent<Stats>().movementRange;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving) {
            
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) <= HittingDistance) {
                moving = false;
                agent.isStopped = true;
                Hit();
            }
        }
    }

    private void Hit()
    {   //tänna animaatiot ja muut paskat
        target.GetComponent<Stats>().TakeDamage(Damage);
        Debug.Log("Giant hittaa hahmoa: " + target + " damagen verran: " + Damage);
        
        EndTurn();
        
    }

   
    private void EndTurn() {
        OnTurnChanged.RaiseAll();
    }

    public void StartTurn()
    {
        agent.SetDestination(target.transform.position);
        agent.isStopped = false;
        moving = true;
    }
}
