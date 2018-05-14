using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : SingletonBehaviour<AbilityManager> {

	public Ability Ability {
		get { return m_selectedAbility; }

		private set {
			m_selectedAbility = value;
		}
	}

	public Ability Hovered {
		get {
			return m_hoveredAbility;
		}

		private set {
			m_hoveredAbility = value;
		}
	}

	private Ability m_selectedAbility = null;
	private Ability m_hoveredAbility = null;

	public void OnTurnChanged() {
		m_selectedAbility = null;
		m_hoveredAbility = null;
	}

	public void SelectedAbility(Ability ability) {
		if (ability != null)
			Debug.Log("Selected: " + ability.name);

		Ability = ability;
	}

	public void HoveredAbility(Ability ability) {
		if (ability != null)
			Debug.Log("Hovering over: " + ability.name);

		Hovered = ability;
	}
}
