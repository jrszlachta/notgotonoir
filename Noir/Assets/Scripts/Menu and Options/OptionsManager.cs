using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider masterVolumeSlider;
	public AudioManager audioMan;

	/* On start, retrieve preferences */
	void Start () {
		audioMan = AudioManager.instance;
		masterVolumeSlider.value = PlayerPrefsInterface.GetMasterVolume();
		audioMan.setMusicVolume(masterVolumeSlider.value); // Set volume to the stored value
		Debug.Log("Changed volume successfully to " + masterVolumeSlider.value);
	}

	public void OnVolumeChanged(){
		audioMan.setMusicVolume(masterVolumeSlider.value); // Set volume to the stored value
		Debug.Log("Changed volume successfully to " + masterVolumeSlider.value);
	}

	public void SaveOptions(){
		PlayerPrefsInterface.SetMasterVolume (masterVolumeSlider.value);
	}
}
