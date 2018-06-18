using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldMovement : MonoBehaviour {

    public GameObject followPoint;

    NavMeshAgent agent;

    public Animator anim;

    public GameObject player;

    bool follow = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if (player.GetComponent<NavMeshAgent>().velocity.magnitude >= 0.11 & follow == true) {
            agent.SetDestination(followPoint.transform.position);
            anim.SetBool("Walking", true);
        }
        

        if (player.GetComponent<NavMeshAgent>().velocity.magnitude <= 0.1) {
            anim.SetBool("Walking", false);
        }
	}

    public void Unfollow() {
        follow = false;
    }

    public void Follow() {
        follow = true;
    }
}
