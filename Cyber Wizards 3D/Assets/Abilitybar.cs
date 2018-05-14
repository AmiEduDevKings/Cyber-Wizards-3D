using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilitybar : MonoBehaviour {

	public GameEvent OnAbilityHovered;
	public GameEvent OnAbilitySelected;
	public GameEvent OnAbilityExit;

	List<GameObject> children = new List<GameObject>();

	public Color color;
	public Color hover;
	public Color selected;

	private void Start() {
		for (int i = 0; i < transform.childCount; i++) {
			children.Add(transform.GetChild(i).gameObject);
			children[i].GetComponent<AbilityButton>().index = i;
		}

		ResetAllExceptSelected();
	}

	public void OnAbilityEnter(int index) {
		children[index].GetComponent<Image>().color = hover;
		AbilityManager.Instance.HoveredAbility(GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[index]);
		OnAbilityHovered.RaiseAll();
	}

	public void AbilityExit(int index) {
		AbilityManager.Instance.HoveredAbility(null);
		ResetAllExceptSelected();
		OnAbilityExit.RaiseAll();
	}

	public void OnClick(int index) {
		ResetAll();
		children[index].GetComponent<Image>().color = selected;
		children[index].GetComponent<AbilityButton>().Selected = true;
		AbilityManager.Instance.SelectedAbility(GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[index]);
		OnAbilitySelected.RaiseAll();
	}

	public void ResetAllExceptSelected() {
		for (int i = 0; i < children.Count; i++) {
			if (!children[i].GetComponent<AbilityButton>().Selected) {
				children[i].GetComponent<Image>().color = color;
			} else {
				children[i].GetComponent<Image>().color = selected;
			}
		}
	}

	public void ResetAll() {
		for (int i = 0; i < children.Count; i++) {
			AbilityManager.Instance.SelectedAbility(null);
			AbilityManager.Instance.HoveredAbility(null);
			children[i].GetComponent<Image>().color = color;
			children[i].GetComponent<AbilityButton>().Selected = false;
		}
	}
}
