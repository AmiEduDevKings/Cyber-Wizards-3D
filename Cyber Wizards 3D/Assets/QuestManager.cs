using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour {

	public static QuestManager instance { get; set; }

	public GameObject QuestPanel;
	[HideInInspector]
	public Text Quest;

	void Awake()
	{


		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}

	}

	private void Start()
	{
#pragma warning disable CS0618 // Type or member is obsolete
		Quest = QuestPanel.transform.FindChild("Quest").GetComponent<Text>();
#pragma warning restore CS0618 // Type or member is obsolete
	}

	public void StartGuest(string quest) {
		Quest.text = quest;
	}


	public void QuestDone() {
		Quest.text = "You Killed Giant";
	}

	public void EndQuest() {
		Quest.text = "Quest done";
	}

}
