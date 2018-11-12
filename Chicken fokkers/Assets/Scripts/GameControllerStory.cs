// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerStory : GameController {

	public Slider progressBar;

	public override void PlayerHasDied(){
		Debug.Log("DIED!");
		ScoreModal.SetActive(true);
		progressBar.value = 0.2f;
		PlayAgainBtn.SetActive(true);
	}
}


