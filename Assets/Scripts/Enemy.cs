using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed; // Speed of the player
	public Transform groundCheck; // Ckeck if the ground is touched
	public LayerMask layerGround; // Variable of the layer
	private bool grounded; // Know when the player is on the ground

	public float radiusCheck;

	private Rigidbody2D rb2D;
	private Animator animator;
	private bool facingRight = true;
	private bool isVisible = false;


	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, layerGround);

		if(!grounded){
			Flip();
		}
	}

	void FixedUpdate(){
		if(isVisible){
			rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
		}
		else{
			rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		speed *= -1;
	}

	void OnBecameVisible(){
		Invoke("MoveEnemy", 1f);
	}

	void OnBecameInvisible(){
		Invoke("StopEnemy", 1f);
	}

	void MoveEnemy(){
		isVisible = true;
		animator.Play("Run");
	}

	void StopEnemy(){
		isVisible = false;
		animator.Play("Idle");
	}
}
