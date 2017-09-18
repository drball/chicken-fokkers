using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool alive = true;
	public int score = 0;
	public GameController GameController;
	public DamageController DamageController;
	public PlayerMovement PlayerMovement;
	public SpriteRenderer Rend;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die(){
		//--trigger a death animation
		// Destroy(gameObject);
		Debug.Log(gameObject.name +" is dead");
		Rend.color = new Color(0, 0, 0, 1); //--make it black

		alive = false;

		//--show the scoreboard - or start another round
		GameController.EndRoundCountdown();

	}

	public void ResetPlayer(){
		
		alive = true;

		DamageController.ResetHealth();

		PlayerMovement.MoveToStartPos();
	}
}
