using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MonoBehaviour {

	[HideInInspector]
	public LevelManager lvlMan;
	public string destination;
	// Use this for initialization
	void Start () {
		lvlMan = FindObjectOfType<LevelManager> ();
	}

	public void enterPortal() {
		lvlMan.ChangeScene (destination);
	}
}
