using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldMovement : MonoBehaviour {

    public GameObject followPoint;

    NavMeshAgent agent;



    bool follow = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if (follow) {
            agent.SetDestination(followPoint.transform.position);
        }
	}

    public void Unfollow() {
        follow = false;
    }

    public void Follow() {
        follow = true;
    }
}
