using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider masterVolumeSlider;
	private PlayerPrefsInterface prefsInterface;

	/* On start, retrieve preferences */
	void Start () {
		prefsInterface = GetComponent<PlayerPrefsInterface> ();
		masterVolumeSlider.value = prefsInterface.GetMasterVolume(); 
		// AudioManager.volume = GetMasterVolume(); // Set volume to the stored value
	}

	public void OnVolumeChanged(){
		// AudioManager.volume = masterVolumeSlider.value
		Debug.Log("Changed volume successfully");
	}
	
	public void SaveOptions(){
		prefsInterface.SetMasterVolume (masterVolumeSlider.value);
	}
}
