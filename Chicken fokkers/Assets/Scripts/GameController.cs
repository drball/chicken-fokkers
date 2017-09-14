using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public PlayerController Player1Controller;
	public PlayerController Player2Controller;
	public int leftEdge = 0;
	public int rightEdge = 900;
	public Camera cam;

	// Use this for initialization
	void Start () {
		Reset();

		Player1.transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Reset(){
		
		Player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		Player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	void EndGame(){
		//--a game consists of 3 rounds, best of 3

	}

	void PlayAgain(){
		Reset();

		Player1Controller.ResetScore();
		Player2Controller.ResetScore();
	}
}
