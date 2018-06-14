using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour {

	public string[] dialogue;
	public string NPCName;
	public string Quest;

	public void OpenDialogue() {
		DialogueSystem.instance.AddNewDialogue(dialogue, NPCName, Quest);
	}

}
