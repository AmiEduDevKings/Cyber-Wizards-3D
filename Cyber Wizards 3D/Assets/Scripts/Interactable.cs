using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

    public float stoppingDistance = 2.5f;

    [HideInInspector]
    NavMeshAgent agent;

    public UnityEvent Event;

    public virtual void MoveToInteraction(NavMeshAgent agent)
    {
        this.agent = agent;
        this.agent.destination = gameObject.transform.position;
        this.agent.stoppingDistance = stoppingDistance;
        this.agent.isStopped = false;

        StartCoroutine(WaitForInteraction());
    }

    public IEnumerator WaitForInteraction()
    {
        while (Vector3.SqrMagnitude(agent.destination - agent.transform.position) > agent.stoppingDistance * agent.stoppingDistance - 1f)
        {
            yield return new WaitForSeconds(0.2f);
        }
        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with Interactable");
        Event.Invoke();
    }
}
