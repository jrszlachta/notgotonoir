using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider musicVolumeSlider;
	public Slider soundsVolumeSlider;
	public AudioManager audioMan;

	/* On start, retrieve preferences */
	void Start () {
		audioMan = AudioManager.instance;
		musicVolumeSlider.value = PlayerPrefsInterface.GetMasterVolume();
		soundsVolumeSlider.value = PlayerPrefsInterface.GetSoundsVolume();
		audioMan.setMusicVolume(musicVolumeSlider.value); // Set volume to the stored value
		audioMan.setGameVolume(soundsVolumeSlider.value); // Set volume to the stored value
		Debug.Log("Changed music volume successfully to " + musicVolumeSlider.value);
		Debug.Log("Changed sounds volume successfully to " + soundsVolumeSlider.value);
	}

	public void OnVolumeChanged(){
		audioMan.setMusicVolume(musicVolumeSlider.value); // Set volume to the stored value
		audioMan.setGameVolume(soundsVolumeSlider.value); // Set volume to the stored value
		Debug.Log("Changed music volume successfully to " + musicVolumeSlider.value);
		Debug.Log("Changed sounds volume successfully to " + soundsVolumeSlider.value);
	}

	public void SaveOptions(){
		PlayerPrefsInterface.SetMasterVolume (musicVolumeSlider.value);
		PlayerPrefsInterface.SetSoundsVolume (soundsVolumeSlider.value);
	}
}
