using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcdialogi : MonoBehaviour {

    public string[] dialogue;
    public string NPCName;
    
    public void OpenDialogue()
    {
        DialogueSystem.instance.AddNewDialogue(dialogue, NPCName);
    }
}
