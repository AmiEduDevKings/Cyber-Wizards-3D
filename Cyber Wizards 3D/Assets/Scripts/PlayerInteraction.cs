using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent agent;
    public bool inCombat;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!inCombat) {
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                GetInteraction();
            }
        }
    }

    public void GetInteraction()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Interactable")
            {
                Debug.Log("interaction löytyi");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(this.agent);
            }
            else
            {
                agent.stoppingDistance = 0f;
                agent.destination = interactionInfo.point;
            }
        }

    }

    public void InCombat() {
        inCombat = true;
    }

    public void UnCombat() {
        inCombat = false;
    }
}
