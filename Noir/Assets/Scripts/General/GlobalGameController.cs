using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameController : MonoBehaviour {

	public Transform[] character;

	// Use this for initialization
	void Start () {
		Instantiate (character [PlayerPrefsInterface.GetCharGender()]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
