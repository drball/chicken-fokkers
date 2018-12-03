﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour {

	public GameObject[] levelButtons;
	public int levelReached;
	public LevelsController LevelsController;

	// Use this for initialization
	void Start () {
		//--load the level reached from playerprefs
		levelReached = PlayerPrefs.GetInt("levelReached",1);
		Debug.Log("level reached = "+levelReached);

		//--show only the buttons for the levels we've finished
		// for(var levelButton : GameObject in levelButtons){
			
		// 	if(levelButtonNum > levelReached ){
		// 		levelButton.GetComponent.<Button>().interactable = false;
		// 	}

		// 	levelButtonNum++;
		// }
	}
	
	void LoadLevelBtnPressed(int levelNum){

		Debug.Log("level button pressed");

		//--menu button pressed
		LevelsController.ShowLoadingDialog();

		// WaitThenLoadLevel(levelNum);
	}
}
