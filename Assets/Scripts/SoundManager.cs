﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

public static SoundManager instance;
public AudioSource fxPlayer;
public AudioSource fxGemCollect;


private void Awake() {
		if (instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void PlayFxPlayer(AudioClip clip){
		fxPlayer.clip = clip;
		fxPlayer.Play();
	}

		public void PlayFxGemCollect(AudioClip clip){
		fxGemCollect.clip = clip;
		fxGemCollect.Play();
	}


}
