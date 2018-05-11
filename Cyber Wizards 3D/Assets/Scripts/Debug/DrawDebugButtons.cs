using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace dks {
	public class DebugRect {

		private float m_buttonWidth;
		private float m_buttonHeight;
		private float m_offset;

		private float m_lastWidth;
		private float m_lastHeight;

		private float m_totalWidth;
		private float m_totalHeight;

		public DebugRect(float buttonWidth, float buttonHeight, float offset) {
			m_buttonWidth = buttonWidth;
			m_buttonHeight = buttonHeight;
			m_offset = offset;
		}

		public Rect Create() {
			Rect r = new Rect(m_lastWidth + m_offset, m_lastHeight + m_offset, m_buttonWidth, m_buttonHeight);

			if (m_lastHeight > Screen.height) {
				m_lastHeight = 0f;
				m_lastWidth += m_lastWidth + m_offset;
			}

			m_lastHeight = m_lastHeight + m_buttonHeight;
			m_totalHeight += m_buttonHeight + m_offset;
			m_totalWidth = m_lastWidth + m_buttonWidth;
			return r;
		}

		public float GetTotalWidth() {
			return m_totalWidth;
		}

		public float GetTotalHeight() {
			return m_totalHeight;
		}
	}
}

public class DrawDebugButtons : MonoBehaviour {

	public GameEvent OnTurnChanged;
	public bool isEnabled = true;
	public GameObject panel;

	const float m_buttonWidth = 100f;
	const float m_buttonHeight = 50f;
	const float m_offset = 10f;

	dks.DebugRect debugRect = new dks.DebugRect(m_buttonWidth, m_buttonHeight, m_offset);

	Rect debugToggle, debugEndturn, debugTestButton1, debugTestButton2;

	private void Start() {
		debugToggle = debugRect.Create();
		debugEndturn = debugRect.Create();
		debugTestButton1 = debugRect.Create();
		debugTestButton2 = debugRect.Create();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			OnTurnChanged.RaiseAll();
		}
	}

	private void OnGUI() {
		if (isEnabled) {
			panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(m_offset, -m_offset);
			panel.GetComponent<RectTransform>().sizeDelta = new Vector2(debugRect.GetTotalWidth() * 1.75f, debugRect.GetTotalHeight() * 1.75f);
			if (GUI.Button(debugToggle, "Disable Debug")) {
				isEnabled = false;
			}
			if (GUI.Button(debugEndturn, "End Turn")) {
				Log("Pressed End Turn button");
				OnTurnChanged.RaiseAll();
			}

			if (GUI.Button(debugTestButton1, "Test Button")) {
				Debug.LogWarning("Unimplemented!");
			}

			if (GUI.Button(debugTestButton2, "Test Button")) {
				Debug.LogWarning("Unimplemented!");
			}

			return;
		}

		panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(m_offset, -m_offset);
		panel.GetComponent<RectTransform>().sizeDelta = new Vector2(m_buttonWidth * 1.75f, m_buttonHeight * 1.75f);

		if (GUI.Button(debugToggle, "Enable Debug")) {
			isEnabled = true;
			return;
		}
	}

	private void Log(string str) {
		Debug.Log("DrawDebugButtons -> " + str);
	}
}
