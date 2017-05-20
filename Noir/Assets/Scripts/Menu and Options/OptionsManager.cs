using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider masterVolumeSlider;
	public MusicManager audioMan;

	/* On start, retrieve preferences */
	void Start () {
		audioMan = GameObject.FindObjectOfType<MusicManager> ();
		masterVolumeSlider.value = PlayerPrefsInterface.GetMasterVolume(); 
		audioMan.GlobalSetVolume(masterVolumeSlider.value); // Set volume to the stored value
	}

	public void OnVolumeChanged(){
		audioMan.GlobalSetVolume(masterVolumeSlider.value); // Set volume to the stored value
		Debug.Log("Changed volume successfully");
	}
	
	public void SaveOptions(){
		PlayerPrefsInterface.SetMasterVolume (masterVolumeSlider.value);
	}
}
