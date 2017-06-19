using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	[Range(0f,1f)]
	public float musicVolume = 1;
	[Range(0f,1f)]
	public float gameVolume = 1;
	public Sound[] sounds;

	// Singleton do gerenciador de áudio
	public static AudioManager instance;

	private Sound activeMusic = null;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			if(s.sceneMusic != null) {
				if(s.volume > musicVolume) {
					s.source.volume = musicVolume;
				}
			} else {
				if(s.volume > gameVolume) {
					s.source.volume = gameVolume;
				}
			}
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start() {
		checkSceneMusic();
	}

	public void Play(string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.volume = gameVolume;
		s.source.Play();
	}

	public void setMusicVolume(float volume) {
		musicVolume = volume;
		try {
			activeMusic.source.volume = musicVolume;
		} catch(NullReferenceException e) {
			Debug.Log("No active music to change the volume");
		}
	}

	public void setGameVolume(float volume) {
		gameVolume = volume;
	}

	void OnEnable() {
		SceneManager.sceneLoaded += checkSceneMusicDelegate;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= checkSceneMusicDelegate;
	}

	void checkSceneMusicDelegate(Scene scene, LoadSceneMode mode) {
		checkSceneMusic();
	}

	void checkSceneMusic() {
		// Play("MainMenu");
		string currentScene = SceneManager.GetActiveScene().name;
		Sound s = Array.Find(sounds, sound => sound.sceneMusic == currentScene);
		if(s != null) {
			if((activeMusic == null) || (activeMusic.name != s.name)) {
				try {
					activeMusic.source.Stop();
				} catch(NullReferenceException e) {
					Debug.Log("Active music is null");
				}
				activeMusic = s;
				activeMusic.source.volume = musicVolume;
				activeMusic.source.Play();
			}
		}
	}

}
