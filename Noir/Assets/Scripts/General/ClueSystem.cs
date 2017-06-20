using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueSystem : MonoBehaviour {

	public static ClueSystem instance;
	public GameObject dialogPanel;

	Button closeButton;
	Text nameText;
	Text itemText;
	Image itemImage;

	[HideInInspector]
	public string name;
	[HideInInspector]
	public string itemDescription;
	[HideInInspector]
	public Sprite magnifiedVersion;

	void Awake() {
		if(instance == null) {
			instance=this;
		} else {
			Destroy(gameObject);
		}

		closeButton = dialogPanel.transform.FindChild("Close").GetComponent<Button>();
		itemText = dialogPanel.transform.FindChild("Text").GetComponent<Text>();
		itemImage = dialogPanel.transform.FindChild("Image").GetComponent<Image>();
		nameText = dialogPanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
		closeButton.onClick.AddListener(delegate { closeDialog(); });

		dialogPanel.SetActive(false);
	}

	public void AddNewClue(string text, string name, Sprite magnifiedVersion) {
		itemDescription = text;
		this.name = name;
		this.magnifiedVersion = magnifiedVersion;
		createClue();
	}

	public void createClue() {
		itemText.text = itemDescription;
		nameText.text = name;
		itemImage.sprite = magnifiedVersion;
		dialogPanel.SetActive(true);
	}

	public void closeDialog() {
		dialogPanel.SetActive(false);
	}
}
