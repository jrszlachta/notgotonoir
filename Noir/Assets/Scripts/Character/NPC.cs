using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

	public string name;
	public string[] dialogue;

	public override void Interact() {
		Debug.Log("Interagindo com NPC " + name);
		DialogueSystem.instance.AddNewDialogue(dialogue, name);
	}
}
