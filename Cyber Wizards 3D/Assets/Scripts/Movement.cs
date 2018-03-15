using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

    NavMeshAgent nav;
    Character character;

    public Vector3 target;
    public LayerMask mask;
    public GameObject pointer;
    public GameObject circleRadiusGO;
    DrawCircle circleRadius;

    private NavMeshPath path;
    private float elapsed = 0.0f;
    private int actionPoints;

    private Vector3[] corners;
    private int posCount;
    private DrawCircle drawCircle;

    float radius;
    float dist;

    bool moving = false;
	TargetClass tc = new TargetClass();

    // Use this for initialization
    void Start() {
        nav = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();
        actionPoints = character.actionPoints;
        path = new NavMeshPath();
        elapsed = 0.0f;
        radius = actionPoints;
        circleRadius = circleRadiusGO.GetComponent<DrawCircle>();
    }

    // Update is called once per frame
    void Update() {
		CalculatePath(tc.GetRayCastHit(Input.mousePosition));

        // Tallennetaan Navmeshin distance
        dist = nav.remainingDistance;

        // Jos ollaan määränpäässä niin laitetaan liikkuminen falseksi
        if (dist != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance == 0) {
            moving = false;
        }

        if (!moving) {
            // Päivitetään navmeshin pathi joka # välein
            elapsed += Time.deltaTime;
            if (elapsed > 0.02f) {
                elapsed -= 0.02f;
                NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
            }
        }
    }

    public void CalculatePath(RaycastHit hit) {

        // Hiiren positioni
        Vector3 mousePosition = hit.point;

        // Liikkumis ympyrän keskipiste
        Vector3 circlePosition = circleRadiusGO.transform.position;

        // Hiiren etäisyys ympyrän keskipisteestä
        float distanceFromCircle = Vector3.Distance(circlePosition, mousePosition);

        // Clämpätään se jollain radiuksella
        distanceFromCircle = Mathf.Clamp(distanceFromCircle, 0, radius);

        // Lasketaan suunta ympyrän keskipisteestä hiireen
        Vector3 dir = mousePosition - circlePosition;

        // Taas clämppiä
        dir = Vector3.ClampMagnitude(dir, radius);

        // En muista miksi tää
        Vector3 pos = circlePosition + (dir.normalized * distanceFromCircle);

        // Laitetaan hiiren pointteri laskettuun positioniin
        pointer.transform.position = pos;

        // Piiretään ray debuggausta varten
        Debug.DrawRay(circlePosition, dir, Color.green);

        RaycastHit hitinfo;

        // Lasketaan hiiren suunta pelaajan hahmosta
        Vector3 dirFromPlayer = pos - transform.position;


        // Tarkistetaan onko seinä hiiren ja pelaajan välissä.
        if (Physics.Raycast(new Ray(transform.position, dirFromPlayer), out hitinfo)) {

            Debug.DrawRay(transform.position, dirFromPlayer, Color.yellow);

            // Jos löytyy seinä, niin laitetaan hiiren-pointteri lähimpään navmesh areaan
            if (hitinfo.collider.CompareTag("Wall")) {
                NavMeshHit hitp;
                if (NavMesh.SamplePosition(hitinfo.point, out hitp, 1f, NavMesh.AllAreas)) {
                    pointer.transform.position = hitp.position;
                }
            }

            // Ei löytynyt seinää, joten liikutaan normaalisti targettiin
            if (hit.transform.CompareTag("Ground")) {
                if (Input.GetMouseButtonDown(0)) {
                    if (!EventSystem.current.IsPointerOverGameObject()) {
                        Move(pointer.transform.position);
                    }
                }
            }
        }
    }

    public void Move(Vector3 destination) {
        nav.SetDestination(destination);
        moving = true;
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
