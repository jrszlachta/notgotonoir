using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressStartControl : MonoBehaviour {

	public float fadeTime; // Time for a fade in/out to happen (total fade out and in interval is double of this value)
	public LevelManager lvlManager;

	private float lastFadeSecond; // Stores last second which a fade (in/out) happened
	private bool inOut = true; // Controls if it fades in or out (out on true)

	private Text thisText;
	private Color currentColor;

	// Use this for initialization
	void Start () {
		lastFadeSecond = Time.time;
		thisText = GetComponent<Text>();
		currentColor = thisText.color;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastFadeSecond < fadeTime) {
			fades ();
		} else {
			inOut = !inOut;
			lastFadeSecond = Time.time;
		}

		if (Input.anyKeyDown) {
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
				return;
			}
			lvlManager.ChangeScene("01a Main Menu"); // TODO: Substitute for actual level name later
		}
	}

	// Method to fade text in or out
	private void fades(){
		float alphaChange = Time.deltaTime / fadeTime;
		if (inOut)
			currentColor.a -= alphaChange;
		else
			currentColor.a += alphaChange;
		thisText.color = currentColor;
	}
}
