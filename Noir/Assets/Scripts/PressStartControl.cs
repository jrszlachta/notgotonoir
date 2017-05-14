using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressStartControl : MonoBehaviour {

	public float fadeTime; // Time for a fade in/out to happen (total fade out and in interval is double of this value)
	public LevelManager lvlManager;

	private float lastFadeSecond; // Stores last second which a fade (in/out) happened
	//private float tempTime; // To use in the fade animation
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
			//tempTime = Time.time;
			//if (inFadeInterval ()) {
			fades ();
			//} else {
				//inOut = !inOut;
				//lastFadeSecond = Time.time;
		} else {
			inOut = !inOut;
			lastFadeSecond = Time.time;	
		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			lvlManager.ChangeScene("work_in_progress"); // TODO: Substitute for actual level name later
		}
	}

	private void fades(){
		float alphaChange = Time.deltaTime / fadeTime;
		if (inOut)
			currentColor.a -= alphaChange;
		else
			currentColor.a += alphaChange;
		thisText.color = currentColor;
	}

	/*private bool inFadeInterval(){
		return (Time.time - tempTime < fadeTime);
	}*/
}
