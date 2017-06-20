using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : Interactable {

	public string name;
	public string itemText;
	public Sprite magnifiedVersion;

	public override void Interact() {
		Debug.Log("Interagindo com item " + name);
		ClueSystem.instance.AddNewClue(itemText, name, magnifiedVersion);
	}
}
