using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	//[Range(50f,100f)]
	public float walkSpeed;
	[HideInInspector]
	public LevelManager lvlMan;
	private Animator animator;
	private SpriteRenderer sprRender;
	private Rigidbody2D rb;
	[HideInInspector]
	public Transform pressE;
	private Collision2D collisionObj = null;
	private AudioManager audioMan;

	// Use this for initialization
	void Start () {
		audioMan = AudioManager.instance;
		animator = GetComponent<Animator> ();
		sprRender = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		lvlMan = FindObjectOfType<LevelManager> ();
		audioMan.Stop("PlayerStep");
	}

	// Update is called once per frame
	void Update () {
		/* Walks Right */
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = false;
			rb.velocity = new Vector2(walkSpeed,0);
			audioMan.Play("PlayerStep");
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
			audioMan.Stop("PlayerStep");
		}

		/* Walks Left */
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = true;
			rb.velocity = new Vector2(-walkSpeed,0);
			audioMan.Play("PlayerStep");
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
			audioMan.Stop("PlayerStep");
		}

		if(Input.GetKeyDown("e")) {
			if(collisionObj != null) {
				collisionObj.gameObject.GetComponent<Interactable>().Interact();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		Transform myE;
		if (coll.gameObject.tag == "Interactable") {
			myE = transform.Find("ECanvas");
			myE.gameObject.SetActive(true);
			collisionObj = coll;
		}

		if (coll.gameObject.tag == "ContinueWall") {
			lvlMan.ChangeScene ("work_in_progress");
		}
		//myE.TakeColisionTag (coll.gameObject.tag);
	}

	void OnCollisionExit2D(Collision2D coll){
		Transform myE;
		if (coll.gameObject.tag == "Interactable") {
			myE = transform.Find("ECanvas");
			myE.gameObject.SetActive(false);
			collisionObj = null;
		}
	}

	void OnDestroy() {
		audioMan.Stop("PlayerStep");
	}
}
