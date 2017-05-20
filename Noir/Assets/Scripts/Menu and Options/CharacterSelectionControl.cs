using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionControl : MonoBehaviour {

	private SpriteRenderer sprRender;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		sprRender = GetComponent<SpriteRenderer> ();
	}

	public void ChangeGender(int gender){
		sprRender.sprite = sprites [gender];
		PlayerPrefsInterface.SetCharGender (gender);
	}
}
