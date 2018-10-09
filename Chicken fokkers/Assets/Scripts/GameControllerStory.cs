using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerStory : MonoBehaviour {

	public PlayerController Player1Controller;
	public bool roundActive = false;
	public LevelsController LevelsController;
	public AdvertsController AdvertsController;
	public GameObject Countdown;

	// Use this for initialization
	void Start () {
		LevelsController = GameObject.Find("LevelsController").GetComponent<LevelsController>();

		Debug.Log("start game controller story");

		Reset();
	}
	
	void Reset(){

		Debug.Log("reset. Start the game! ");
		Countdown.SetActive(true);

		//--each player has it's own reset function
		Player1Controller.ResetPlayer();
	}

	public void PlayAgain(){

		//--a full reset

		Debug.Log("play again "+LevelsController.currentLevel);
		
		Reset();
		
		Player1Controller.score = 0;
		
		//--reload entire scene
		LevelsController.LoadSelectedLevel();
	}
}


