using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleCharacterControl : MonoBehaviour {

	//[Range(50f,100f)]
	public float walkSpeed;
	private Animator animator;
	private SpriteRenderer sprRender;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		sprRender = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* Walks Right */
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = false;
			//transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
			rb.velocity = new Vector2(walkSpeed,0);
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
		}

		/* Walks Left */
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", true);
			sprRender.flipX = true;
			//transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
			rb.velocity = new Vector2(-walkSpeed,0);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetBool ("WalkBool", false);
			rb.velocity = new Vector2(0,0);
		}
	}
}
