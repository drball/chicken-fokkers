using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //--enables us to access <Text>
using UnityEngine;

public class GameController : MonoBehaviour {

	// public GameObject Player1;
	// public GameObject Player2;
	public PlayerController Player1Controller;
	public PlayerController Player2Controller;
	public int leftEdge = 0;
	public int rightEdge = 900;
	public bool roundActive = false;
	public GameObject ScoreModal;
	public GameObject PlayAgainBtn;
	public GameObject Player1ScoreText;
	public GameObject Player2ScoreText;
	public LevelsController LevelsController;

	private int winningScore = 5;
	

	// Use this for initialization
	void Start () {

		ScoreModal.SetActive(false);
		PlayAgainBtn.SetActive(false);

		LevelsController = GameObject.Find("LevelsController").GetComponent<LevelsController>();

		Reset();
	}

	void Reset(){

		Debug.Log("reset. Start the round");

		//--start the round
		roundActive = true;

		//--make sure these are hidden so we can activate them later
		ScoreModal.SetActive(false);
		PlayAgainBtn.SetActive(false);

		//--each player has it's own reset function
		Player1Controller.ResetPlayer();
		Player2Controller.ResetPlayer();
	}

	void EndGame(){
		//--a game consists of 3 rounds, best of 3

	}

	public void EndRoundCountdown(){
		//--start the countdown for the end of round
		// Invoke("EndRound",3);
		StartCoroutine("EndRound");
		Debug.Log("Ending round in 3");

    }

	IEnumerator EndRound(){

		yield return new WaitForSeconds(1.00f);

		Debug.Log("The round has ended");

		//--show modal
		ScoreModal.SetActive(true);

		//--determine who won
		if(!Player1Controller.alive) {
			Player2Controller.score++;
			Player2Controller.StartAutopilot();
		}
		
		if(!Player2Controller.alive) {
			Player1Controller.score++;
			Player1Controller.StartAutopilot();
		}

		//--update leaderboard after a few seconds 
		yield return new WaitForSeconds(1.5f);
		
		Player1ScoreText.GetComponent<Text>().text = Player1Controller.score.ToString();
		Player2ScoreText.GetComponent<Text>().text = Player2Controller.score.ToString();

		yield return new WaitForSeconds(1.5f);

		//--decide if someone has won
		if((Player1Controller.score >= winningScore) || (Player2Controller.score >= winningScore)){

			//--someone has won the game
			Debug.Log("someone has won");
			
			//--show "play again" button
			PlayAgainBtn.SetActive(true);

			yield return new WaitForSeconds(1f);

			// AdvertController.ShowAdvert();
			
		}else {
			//--keep playing. Start next round
			
			Reset();
			
		}
	}

	public void PlayAgain(){

		//--a full reset

		Debug.Log("play again "+LevelsController.currentLevel);
		
		Reset();
		
		Player1Controller.score = 0;
		Player2Controller.score = 0;
		
		// //--reset the text boxes
		Debug.Log("reset text values");
		Player1ScoreText.GetComponent<Text>().text = "0";
		Player2ScoreText.GetComponent<Text>().text = "0";
		
		//--reload entire scene
		LevelsController.LoadSelectedLevel();
	}

	void FixedUpdate () {


		// if(Input.GetKey("f")){
		// 	Player1Controller.Die();
		// }
	}
}
