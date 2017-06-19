using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

	void Awake(){
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on load: " + name);
	}

    // Use this for initialization
    void Start(){
        audioSource = GetComponent<AudioSource>();
		audioSource.clip = levelMusicChangeArray [SceneManager.GetActiveScene ().buildIndex];
		audioSource.loop = true;
		audioSource.Play ();
    }

	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
		Debug.Log("Playing clip: " + thisLevelMusic);

		if (thisLevelMusic){ // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

    public void GlobalSetVolume(float volume){
      audioSource.volume = volume;
    }
}
