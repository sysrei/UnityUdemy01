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

private RigidBody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<RigidBody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, layerGround);
	}

	void FixedUpdate(){







	}

	void PlayAnimations(){

	}



}
