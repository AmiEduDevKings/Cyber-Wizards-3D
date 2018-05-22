using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawAbilityCircle : MonoBehaviour {

	public Color targeting;

	[Range(0, 50)]
	public int segments = 50;

	LineRenderer line;

	void Awake() {
		line = gameObject.GetComponent<LineRenderer>();
		line.positionCount = segments + 1;
		line.useWorldSpace = false;
	}

	public void CreateAbilityRangePoints(float xradius, float yradius) {
		line.positionCount = segments + 1;
		float x;
		//float y;
		float z;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++) {
			x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;
			line.SetPosition(i, new Vector3(x, -0.5f, z));

			angle += (360f / segments);
		}
	}

	public void CreateMovementRangePoints(float xradius, float yradius) {
		line.positionCount = segments + 1;
		float x;
		//float y;
		float z;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++) {
			x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;
			line.SetPosition(i, new Vector3(x, -0.5f, z));

			angle += (360f / segments);
		}
	}

	public void RemovePoints() {
		line.positionCount = 0;
	}

	public void OnTurnMasterChanged() {
		RemovePoints();
	}

	public void OnAbilitySelected() {
		RemovePoints();
		GameObject c = GameManager.Instance.TurnMaster;
		transform.position = c.transform.position;
		Ability a = AbilityManager.Instance.Ability;
		CreateAbilityRangePoints(a.range, a.range);
	}

	public void OnAbilityHovered() {
		RemovePoints();
		line.materials[0].color = targeting;
		GameObject c = GameManager.Instance.TurnMaster;
		transform.SetParent(c.transform);
		transform.position = c.transform.position;
		Ability a = AbilityManager.Instance.Hovered;
		CreateAbilityRangePoints(a.range, a.range);
	}

	public void OnAbilityExit() {
		if (AbilityManager.Instance.Ability != null) {
			OnAbilitySelected();
			return;
		}

		transform.SetParent(null);
		RemovePoints();
	}
}
