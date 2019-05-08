using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour {

void OnTriggerEnter2D(Collider2D otherObject){
	if(otherObject.CompareTag("Player"))
	{
		GameManager.instance.score++;
		Destroy(gameObject);
	}
}

}
