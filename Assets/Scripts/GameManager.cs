﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Sprite[] overlaySprites;
	public Image overlay;
	public Text timeHUD;
	public Text scoreHUD;

	public float time;
	public int score;

	public enum GameStatus{WIN, LOSE, DIE, PLAY};
	public GameStatus status;

	 private void Awake() {
		if (instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}

	}
	 
	void Start () {
		time = 60f;
		score = 0;
		status = GameStatus.PLAY;
		overlay.enabled = false;
		Physics2D.IgnoreLayerCollision(9, 10, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(status == GameStatus.PLAY){
			time -= Time.deltaTime;
			int timeInt = (int)time;

			if(timeInt >= 0){
				timeHUD.text = "Time: " + timeInt.ToString();
				scoreHUD.text = "Score: " + score.ToString();
			}

		}
		else if(Input.GetButtonDown("Jump")){
			if(status == GameStatus.WIN){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			else{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void SetOverlay(GameStatus pStatus){
		status = pStatus;
		overlay.enabled = true;
		overlay.sprite = overlaySprites[(int)pStatus];
	}
}
