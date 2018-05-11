using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : SingletonBehaviour<AbilityManager> {

	public Ability Ability {
		get { return m_selectedAbility; }
	}

	public Ability HoveredAbility {
		get {
			return m_hoveredAbility;
		}
	}

	private Ability m_selectedAbility = null;
	private Ability m_hoveredAbility = null;

	public void OnAbilitySelected1() {
		m_selectedAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[0];

		if (GameManager.Instance.m_DebugLogging)
			Debug.Log("AbilityManager -> Selected Ability:" + m_selectedAbility.name);
	}

	public void OnAbilitySelected2() {
		m_selectedAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[1];

		if (GameManager.Instance.m_DebugLogging)
			Debug.Log("AbilityManager -> Selected Ability:" + m_selectedAbility.name);
	}

	public void OnAbilitySelected3() {
		m_selectedAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[2];

		if (GameManager.Instance.m_DebugLogging)
			Debug.Log("AbilityManager -> Selected Ability:" + m_selectedAbility.name);
	}

	public void OnAbilityHovered1() {
		m_hoveredAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[0];
	}

	public void OnAbilityHovered2() {
		m_hoveredAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[1];
	}

	public void OnAbilityHovered3() {
		m_hoveredAbility = GameManager.Instance.TurnMaster.GetComponent<AbilityList>().abilityList[2];
	}

	public void OnTurnChanged() {
		m_selectedAbility = null;
		m_hoveredAbility = null;
	}
}
