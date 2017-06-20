using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem instance;
	public GameObject dialogPanel;

	Button continueButton;
	Text nameText;
	Text dialogueText;
	int dialogueIndex;

	[HideInInspector]
	public string name;
	[HideInInspector]
	public List<string> dialogueLines = new List<string>();

	void Awake() {
		if(instance == null) {
			instance=this;
		} else {
			Destroy(gameObject);
		}

		continueButton = dialogPanel.transform.FindChild("Continue").GetComponent<Button>();
		dialogueText = dialogPanel.transform.FindChild("Text").GetComponent<Text>();
		nameText = dialogPanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
		continueButton.onClick.AddListener(delegate { continueDialog(); });

		dialogPanel.SetActive(false);
	}

	public void AddNewDialogue(string[] lines, string name) {
		dialogueIndex = 0;
		dialogueLines = new List<string>(lines.Length);
		dialogueLines.AddRange(lines);
		this.name = name;
		createDialogue();
	}

	public void createDialogue() {
		dialogueText.text = dialogueLines[dialogueIndex];
		nameText.text = name;
		dialogPanel.SetActive(true);
	}

	public void continueDialog() {
		if(dialogueIndex < dialogueLines.Count) {
			dialogueText.text = dialogueLines[dialogueIndex];
			dialogueIndex++;
		} else {
			dialogPanel.SetActive(false);
		}
	}
}
