using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameControl : MonoBehaviour {

	public AudioManager audioMan;

	// Use this for initialization
	void Start () {
		audioMan.setMusicVolume(PlayerPrefsInterface.GetMasterVolume()); // Set volume to the value stored previously
	}
}
