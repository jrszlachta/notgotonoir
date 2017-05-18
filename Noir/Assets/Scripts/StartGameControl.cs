using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameControl : MonoBehaviour {

	public MusicManager audioMan;

	// Use this for initialization
	void Start () {
		audioMan = GameObject.FindObjectOfType<MusicManager> ();
		audioMan.GlobalSetVolume(PlayerPrefsInterface.GetMasterVolume()); // Set volume to the value stored previously
	}
}
