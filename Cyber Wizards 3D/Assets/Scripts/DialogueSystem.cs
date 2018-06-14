using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	
	public static DialogueSystem instance { get; set; }
	public GameObject DialoguePanel;

	[HideInInspector]
	public List<string> dialogueLines = new List<string>();
	public string NPCName;

	Button continueButton;
	Text dialogueText, nameText;
	public string Quest;

	int dialogueIndex;

	void Awake () {

		
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
		continueButton = DialoguePanel.transform.Find("Continue_Button").GetComponent<Button>();

#pragma warning disable CS0618 // Type or member is obsolete
		dialogueText = DialoguePanel.transform.FindChild("Text").GetComponent<Text>();
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
		nameText = DialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
#pragma warning restore CS0618 // Type or member is obsolete

		continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

		DialoguePanel.SetActive(false);

	}


	public void AddNewDialogue(string line, string NPCName, string Quest) {
		dialogueIndex = 0;
		dialogueLines = new List<string>(1);
		dialogueLines.Add(line);

		this.NPCName = NPCName;
		Debug.Log(dialogueLines.Count);

		this.Quest = Quest;

		CreateDialogue();
	}

	public void AddNewDialogue(string[] lines, string NPCName, string Quest)
	{

		dialogueIndex = 0;
		dialogueLines = new List<string>(lines.Length);
		dialogueLines.AddRange(lines);

		this.NPCName = NPCName;
		Debug.Log(dialogueLines.Count);

		this.Quest = Quest;

		CreateDialogue();
	}

	private void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count - 1)
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines[dialogueIndex];
		}
		else {
			DialoguePanel.SetActive(false);
			QuestManager.instance.StartGuest(Quest);
		}
	}

	public void CreateDialogue() {
		dialogueText.text = dialogueLines[dialogueIndex];
		nameText.text = NPCName;
		DialoguePanel.SetActive(true);
	}

	
}
