using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInterface : MonoBehaviour {

	/* Definitions of option strings */

	const string MASTER_VOLUME_KEY = "master_volume";
	//const string DIFFICULTY_KEY = "difficulty";
	// TODO: Think about other options
		
	/* Interface methods */

	public void SetMasterVolume(float newVolume){
		PlayerPrefs.SetFloat (MASTER_VOLUME_KEY,newVolume);
	}

	public float GetMasterVolume(){
		return (PlayerPrefs.GetFloat (MASTER_VOLUME_KEY));
	}
}
