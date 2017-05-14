using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameControl : MonoBehaviour {

	private PlayerPrefsInterface prefsInterface;

	// Use this for initialization
	void Start () {
		prefsInterface.GetComponent<PlayerPrefsInterface>();
		// AudioManager.volume = prefsInterface.GetMasterVolume(); // Set volume to the value stored previously
	}
}
