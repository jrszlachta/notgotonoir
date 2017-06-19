using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleCharacterControl : MonoBehaviour {

	//[Range(50f,100f)]
	public float walkSpeed;
	public LevelManager lvlMan;
	private Animator animator;
	private SpriteRenderer sprRender;
	private Rigidbody2D rb;
	public Transform pressE;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		sprRender = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		lvlMan = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* Walks Right */
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = false;
			rb.velocity = new Vector2(walkSpeed,0);
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
		}

		/* Walks Left */
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = true;
			rb.velocity = new Vector2(-walkSpeed,0);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		Transform myE;
		if (coll.gameObject.tag == "NPC") {
			myE = transform.Find("ECanvas");
			myE.gameObject.SetActive(true);
		}
			
		if (coll.gameObject.tag == "ContinueWall") {
			lvlMan.ChangeScene ("work_in_progress");
		}
		//myE.TakeColisionTag (coll.gameObject.tag);
	}

	void OnCollisionExit2D(Collision2D coll){
		Transform myE;
		if (coll.gameObject.tag == "NPC") {
			myE = transform.Find("ECanvas");
			myE.gameObject.SetActive(false);
		}
	}
}
