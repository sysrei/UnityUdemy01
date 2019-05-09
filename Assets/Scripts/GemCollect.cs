using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour {

public AudioClip fxCollect;
void OnTriggerEnter2D(Collider2D otherObject){
	if(otherObject.CompareTag("Player"))
	{
		GameManager.instance.score++;
		SoundManager.instance.PlayFxGemCollect(fxCollect); 
		Destroy(gameObject);
	}
}

}
