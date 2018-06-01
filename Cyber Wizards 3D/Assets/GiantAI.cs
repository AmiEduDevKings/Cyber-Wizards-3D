using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantAI : MonoBehaviour {

    public GameObject[] Characters;

    public bool moving = false;
    private NavMeshAgent agent;
    public float movementRange;
    public float moved;
    public float path;
    GameObject target;
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
        Debug.Log("hittaa hahmoa: " + target + " damagen verran: " + Damage);
        Debug.Log(Vector3.Distance(target.transform.position, gameObject.transform.position));
    }

    public GameObject GetTargetPosition()
    {
        float dist = 0;
        target = Characters[0];
        for (int i = 0; i < Characters.Length; i++)
        {

            if (dist < Vector3.Distance(gameObject.transform.position, Characters[i].transform.position))
            {
                dist = Vector3.Distance(gameObject.transform.position, Characters[i].transform.position);
                target = Characters[i];
            }

        }
        
        return target;
    }

    public void StartTurn()
    {
        agent.SetDestination(GetTargetPosition().transform.position);
        agent.isStopped = false;
        moving = true;
        path = agent.destination.magnitude;
    
    }
}
