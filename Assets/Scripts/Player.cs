using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

public float speed; // Speed of the player
public int jumpPower; // Power oh the jump
public Transform groundCheck; // Ckeck if the ground is touched

public LayerMask layerGround; // Variable of the layer
private bool grounded; // Know when the player is on the ground
private bool jumping; //Know if the player is jumping

public float radiusCheck;

private Rigidbody2D rb2D;
private Animator animator;
private bool facingRight = true;
private bool isAlive = true;



	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, layerGround);

		//???????? Colocar no fixed para testar
		if(Input.GetButtonDown("Jump") && grounded){
			//Jump commands
			jumping = true;
		}
		PlayAnimations();
	}

	void FixedUpdate(){

		
		if(isAlive){
		float move = Input.GetAxis("Horizontal");
		rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

		if(move < 0 && facingRight || move > 0 && !facingRight){
			Flip();
		}

		if(jumping){
			rb2D.AddForce(new Vector2(0f, jumpPower));
			jumping = false;
		}
		}
		else{
			rb2D.velocity = new Vector2(0, rb2D.velocity.y);
		}


	}

	void PlayAnimations(){

		if(!isAlive){
			animator.Play("Die");
		}
		else if(grounded && rb2D.velocity.x != 0){
			animator.Play("Run");
		}
		else if(grounded && rb2D.velocity.x == 0){
			animator.Play("Idle");
		}
		else if(!grounded){
			animator.Play("Jump");
		}
	}

	void Flip(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void OnCollisionEnter2D(Collision2D otherObject){

		if(otherObject.gameObject.CompareTag("Enemy")){
		PlayerDie();
		}
	}
	
	void PlayerDie(){
		isAlive = false;
		Physics2D.IgnoreLayerCollision(9, 10);
	}

}
