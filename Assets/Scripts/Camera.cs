using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	private Vector2 velocity;

	public Transform targetPlayer;
	public Vector2 smoothTime;
	public Vector2 maxLimit;
	public Vector2 minLimit;



	// Use this for initialization
	void Start () {
		// transform.position = new Vector3(targetPlayer.position.x, targetPlayer.position.y, transform.position.z)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
