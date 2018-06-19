using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour {

    [HideInInspector]
    public NavMeshAgent agent;
    public bool inCombat;
    public Animator anim;
   

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

        if (agent.velocity.magnitude <= 0.01) {
            anim.SetBool("Walking", false);
        }

        if (agent.velocity.magnitude >= 0.4) {
            anim.SetBool("Walking", true);
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
                anim.SetBool("Walking", true);
            }
            else
            {
                agent.stoppingDistance = 0.0f;
                agent.destination = interactionInfo.point;
                anim.SetBool("Walking", true);
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
