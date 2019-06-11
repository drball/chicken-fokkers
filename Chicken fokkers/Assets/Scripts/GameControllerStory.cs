﻿// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerStory : GameController {

	public Slider progressBar;
	public GameObject EndParticlesObj;
	public GameObject LevelCompleteModal;
	public GameObject StartPosObj; //--to measure distance
	public GameObject GoalObj; //--to measure distance
	// public GameObject PlayerObj; //--to measure distance
	private float travelledDistance;
	public CameraFollow CameraFollow;

	void Start () {
		base.Start ();
		LevelCompleteModal.SetActive(false);
		Debug.Log("start gamecontroller story");
		CameraFollow = cam.GetComponent<CameraFollow>();
		Debug.Log("-----------------assign camera target");
		CameraFollow.target = Player1Obj.transform;

		if(gameMode == GameModes.Story){
			Player1Obj.GetComponent<PlayerResetAtEdge>().enabled = false;
		}
	}

	public override void PlayerHasDied(){
		Debug.Log("DIED!");
		
		if(roundActive){
			travelDistance();
			progressBar.value = travelledDistance/100;
			ScoreModal.SetActive(true);
			roundActive = false;
		}
	}

	public void ReachedGoal(){
		Debug.Log("reached");
		Player1Controller.StartAutopilot();
		LevelCompleteModal.SetActive(true);
		roundActive = false;
		Invoke("ShowGoalParticles",0.5f);
		roundActive = false;
	}

	void ShowGoalParticles(){
		EndParticlesObj.SetActive(true);
	}

	void travelDistance(){

		float levelDistance =  Mathf.Abs(GoalObj.transform.position.x - StartPosObj.transform.position.x);
		Debug.Log("distance = "+levelDistance);
		travelledDistance = Mathf.Clamp((Player1Obj.transform.position.x / levelDistance)*100,0,100);
		Debug.Log("player got "+travelledDistance+"%");
	}
}


