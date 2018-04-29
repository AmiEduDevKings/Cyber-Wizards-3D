using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

	NavMeshAgent nav;
	CharacterStats character;
	public Raycaster caster;
	[Range(1, 50)]
	public float movementRange;

	public Vector3 target;
	public LayerMask mask;
	public GameObject pointer;
	public GameObject circleRadiusGO;
	DrawCircle circleRadius;

	private NavMeshPath path;

	private Vector3[] corners;
	private int posCount;
	private DrawCircle drawCircle;

	float radius;
	float dist;

	// Use this for initialization
	void Start() {
		nav = GetComponent<NavMeshAgent>();
		path = new NavMeshPath();

		try {
			circleRadius = circleRadiusGO.GetComponent<DrawCircle>();
		} catch {
			Debug.Log("Could not find CircleRadius");
		}
		circleRadius.xradius = movementRange;
		circleRadius.yradius = movementRange;
	}

	// Update is called once per frame
	public void GetMovement() {
		// Tallennetaan Navmeshin distance
		dist = nav.remainingDistance;

		// Jos ollaan määränpäässä niin laitetaan liikkuminen falseksi
		if (dist != Mathf.Infinity && nav.pathStatus == NavMeshPathStatus.PathComplete && nav.remainingDistance == 0) {
			GameManager.Instance.moving = false;
		}


		if (caster.CheckHit(mask) && !EventSystem.current.IsPointerOverGameObject()) {
			EnablePointer();
			if (!GameManager.Instance.moving && !GameManager.Instance.casting) {
				CalculatePath(caster.GetHit());
			}
		} else {
			DisablePointer();
		}

		//if (!moving) {
		//Päivitetään navmeshin pathi joka # välein
		//elapsed += Time.deltaTime;
		//if (elapsed > 0.02f) {
		//    elapsed -= 0.02f;
		//    NavMesh.CalculatePath(raypoint.position, target, NavMesh.AllAreas, path);
		//}
		//}
	}

	public void CalculatePath(RaycastHit hit) {

		// Hiiren worldspace positioni
		Vector3 mousePosition = hit.point;

		// Liikkumisalue ympyrän keskipiste
		Vector3 circlePosition = new Vector3(circleRadiusGO.transform.position.x, 0f, circleRadiusGO.transform.position.z);

		// Hiiren etäisyys ympyrän keskipisteestä
		float mouseDistanceFromCircle = Vector3.Distance(circlePosition, mousePosition);

		// Clämpätään se pelaajan liikkumis etäisyydellä
		mouseDistanceFromCircle = Mathf.Clamp(mouseDistanceFromCircle, 0f, movementRange);

		// Luodaan vektori ympyrän keskipisteestä hiireen
		Vector3 dir = mousePosition - circlePosition;

		dir = Vector3.ClampMagnitude(dir, movementRange);

		// Lasketaan 3D hiiren sijainti
		Vector3 pointerPosition = circlePosition + (dir.normalized * mouseDistanceFromCircle);

		// Laitetaan 3D hiiren laskettuun sijaintiin
		pointer.transform.position = pointerPosition;

		// Piiretään ray debuggausta varten
		Debug.DrawRay(circlePosition, dir, Color.green);

		// Lasketaan 3D hiiren suunta pelaajan hahmosta
		Vector3 dirFromPlayer = pointerPosition - transform.position;

		// Tarkistetaan onko seinä 3D hiiren ja pelaajan välissä.
		RaycastHit hitinfo;
		if (Physics.Raycast(new Ray(transform.position, dirFromPlayer), out hitinfo, Mathf.Infinity)) {
			Debug.DrawRay(transform.position, dirFromPlayer, Color.yellow);
			NavMeshHit hitp;

			// Jos löytyy seinä, niin laitetaan 3D hiiren lähimpään navmesh areaan
			if (hitinfo.collider.CompareTag("Wall")) {
				if (NavMesh.SamplePosition(hitinfo.point, out hitp, 5f, NavMesh.AllAreas)) {
					pointer.transform.position = hitp.position;
				}
			}

			// Ei löytynyt seinää, joten liikutaan normaalisti 3D hiiren sijaintiin
			if (hit.transform.CompareTag("Ground")) {
				if (NavMesh.SamplePosition(hitinfo.point, out hitp, 5f, NavMesh.AllAreas)) {
					if (Input.GetMouseButtonDown(0)) {
						Move(hitp.position);
					}
				}
			}
		}
	}

	public void Move(Vector3 destination) {
		nav.SetDestination(destination);
		GameManager.Instance.moving = true;
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

	private void OnEnable() {
		circleRadius = circleRadiusGO.GetComponent<DrawCircle>();
		circleRadius.xradius = movementRange;
		circleRadius.yradius = movementRange;
	}

	public void EnablePointer() {
		if (!pointer.activeSelf) {
			pointer.SetActive(true);
		}
	}

	public void DisablePointer() {
		if (pointer.activeSelf) {
			pointer.SetActive(false);
		}
	}
}
