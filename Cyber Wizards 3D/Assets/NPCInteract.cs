using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour {

	public string[] dialogue;
	public string NPCName;
	public string Quest;

    public bool questDone = false;
    public string secondDialogue;

	public void OpenDialogue() {
        if (questDone)
        {
            DialogueSystem.instance.AddNewDialogue(secondDialogue, NPCName, " ");
        }
        else
        {
            DialogueSystem.instance.AddNewDialogue(dialogue, NPCName, Quest);
        }
    }

    public void QuestDone() {
        questDone = true;
    }


   
}
