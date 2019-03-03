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
	public bool roundActive = false;
	public GameObject ScoreModal;
	public GameObject PlayAgainBtn;
	public GameObject Player1ScoreText;
	public GameObject Player2ScoreText;
	public LevelsController LevelsController;
	public AdvertsController AdvertsController;
	public GameObject Countdown;
	private int winningScore = 5;
	public GameObject[] Player1Characters;
	public GameObject[] Player2Characters;
	public GameObject Player1Obj;
	public GameObject Player2Obj;
	public GameObject Player1Dummy;
	public GameObject Player2Dummy;
	public Camera cam;
	public GameObject InstructionP1;
	public GameObject InstructionP2;

	void Awake(){
		//--load the correct player
		Debug.Log("GameController");
		Player1Obj = Instantiate(Player1Characters[1], Player1Dummy.transform.position, Player1Dummy.transform.rotation);
		Player2Obj = Instantiate(Player2Characters[1], Player2Dummy.transform.position, Player2Dummy.transform.rotation);
		Destroy(Player1Dummy);
		Destroy(Player2Dummy);

		//--get all the scripts for the players
		Player1Controller = Player1Obj.GetComponent<PlayerController>();
		Player2Controller = Player2Obj.GetComponent<PlayerController>();
	}

	// Use this for initialization
	public void Start () {

		Debug.Log("start gamecontroller normal");

		ScoreModal.SetActive(false);
		PlayAgainBtn.SetActive(false);

		LevelsController = GameObject.Find("LevelsController").GetComponent<LevelsController>();

		Reset();
	}

	void Reset(){

		Debug.Log("reset. Start the round");

		//--start the round
		roundActive = true;
		Countdown.SetActive(true);
		LevelsController.HideLoadingDialog();

		//--make sure these are hidden so we can activate them later
		ScoreModal.SetActive(false);
		PlayAgainBtn.SetActive(false);

		//--each player has it's own reset function
		Player1Controller.ResetPlayer();

		if(Player2Controller){
			Player2Controller.ResetPlayer();
		}
	}

	void EndGame(){
		//--a game consists of 3 rounds, best of 3
	}

	public virtual void PlayerHasDied(){
		EndRoundCountdown();
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

			AdvertsController.ShowAdvert();
			
		}else {
			//--keep playing. Start next round
			
			Reset();
			
		}
	}

	public void PlayAgain(){

		//--a full reset

		Debug.Log("play again "+LevelsController.currentLevel);
		
		//--reload entire scene
		LevelsController.LoadSelectedLevel();
	}


	void FixedUpdate () {

		if(Input.GetKey("a")){
			// Player1Controller.Die();
			Player1Controller.StartAutopilot();
		} else if (Input.GetKey("w")) {
			winningScore = 1;
		} 
	}
}
