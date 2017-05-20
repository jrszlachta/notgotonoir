using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInterface : MonoBehaviour {

	/* Definitions of option strings */

	const string MASTER_VOLUME_KEY = "master_volume";
	const string CHARACTER_GENDER = "char_gender";
	// TODO: Think about other options
		
	/* Interface methods */

	public static void SetMasterVolume(float newVolume){
		PlayerPrefs.SetFloat (MASTER_VOLUME_KEY,newVolume);
	}

	public static float GetMasterVolume(){
		return (PlayerPrefs.GetFloat (MASTER_VOLUME_KEY));
	}

	public static void SetCharGender(int gender){
		PlayerPrefs.SetInt (CHARACTER_GENDER, gender);
	}

	public static int GetCharGender(){
		return (PlayerPrefs.GetInt (CHARACTER_GENDER));
	}
}
