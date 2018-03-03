﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour {

    NavMeshAgent nav;

    public Vector3 target;
    private NavMeshPath path;
    private float elapsed = 0.0f;

    public LineRenderer lr;

    bool moving = false;

    // Use this for initialization
    void Start() {
        nav = GetComponent<NavMeshAgent>();

        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update() {

        float dist = nav.remainingDistance;
        if (dist != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance == 0) {
            moving = false;
        }

        if (!moving) {
            // Update the way to the goal every second.
            elapsed += Time.deltaTime;
            if (elapsed > 0.02f) {
                elapsed -= 0.02f;
                NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
                lr.material.SetColor("_EmissionColor", Color.green);
            }

            lr.positionCount = path.corners.Length;
            lr.SetPositions(path.corners);

            for (int i = 0; i < path.corners.Length - 1; i++) {

                if (i <= path.corners.Length - 2) {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                    continue;
                }

                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.green);

            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.CompareTag("Ground")) {
                    //nav.SetDestination(hit.point);
                    target = hit.point;

                    if (Input.GetMouseButtonDown(0)) {
                        nav.SetDestination(target);
                        moving = true;
                    }
                }

                if (hit.transform.CompareTag("Enemy")) {
                    lr.material.SetColor("_EmissionColor", Color.red);
                    target = hit.transform.position;

                    if (Input.GetMouseButtonDown(0)) {
                        Debug.Log("Attacking enemy");
                    }
                }
            }
        }
    }
}
