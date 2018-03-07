using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour {

    NavMeshAgent nav;
    Character player;
    TurnStatus turnStatus;

    public Vector3 target;
    public LayerMask mask;

    private NavMeshPath path;
    private float elapsed = 0.0f;
    private int actionPoints;

    private Vector3[] corners;
    private int posCount;
    private DrawCircle drawCircle;

    float radius;
    public LineRenderer lr;

    bool moving = false;
    bool circleDrawn = false;

    // Use this for initialization
    void Start() {
        nav = GetComponent<NavMeshAgent>();
        player = GetComponent<Character>();
        drawCircle = GetComponentInChildren<DrawCircle>();
        actionPoints = player.actionPoints;
        path = new NavMeshPath();
        elapsed = 0.0f;
        radius = actionPoints;
        turnStatus = GetComponent<TurnStatus>();
    }

    // Update is called once per frame
    void Update() {

        float dist = nav.remainingDistance;
        if (dist != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance == 0) {
            moving = false;

            if (!circleDrawn) {
                drawCircle.CreatePoints();
                circleDrawn = true;
            }
        }

        if (!moving && !EventSystem.current.IsPointerOverGameObject()) {
            // Update the way to the goal every second.
            elapsed += Time.deltaTime;
            if (elapsed > 0.02f) {
                elapsed -= 0.02f;
                NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
            }

            lr.positionCount = path.corners.Length;
            lr.SetPositions(path.corners);

            //for (int i = 0; i < path.corners.Length - 1; i++) {

            //    if (i <= path.corners.Length - 2) {
            //        Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            //        continue;
            //    }

            //    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.green);

            //}

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask)) {

                Vector3 mousePosition = hit.point;
                Vector3 playerPosition = transform.position;

                float distanceFromPlayer = Vector3.Distance(playerPosition, mousePosition);
                distanceFromPlayer = Mathf.Clamp(distanceFromPlayer, 0, radius);
                Vector3 dir = mousePosition - playerPosition;
                dir = Vector3.ClampMagnitude(dir, radius);

                Vector3 pos = playerPosition + (dir.normalized * distanceFromPlayer);

                if (hit.transform.CompareTag("Ground")) {
                    //nav.SetDestination(hit.point);
                    NavMeshHit hitp;
                    if (NavMesh.SamplePosition(pos, out hitp, 1f, NavMesh.AllAreas)) {
                        target = hitp.position;
                    }

                    if (Input.GetMouseButtonDown(0)) {
                        nav.SetDestination(lr.GetPosition(lr.positionCount - 1));
                        moving = true;
                        drawCircle.RemovePoints();
                        circleDrawn = false;
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

    public int GetPathLength(Vector3[] corners) {
        float lng = 0.0f;

        if ((path.status != NavMeshPathStatus.PathInvalid)) {
            for (int i = 1; i < corners.Length; ++i) {
                lng += Vector3.Distance(corners[i - 1], corners[i]);
            }
        }

        return (Mathf.RoundToInt(lng) / 2) + 1;
    }
}
