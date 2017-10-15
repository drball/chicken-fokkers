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
	public GameObject DeathExplosion;
	public GameObject Vfx;
	public GameObject colliderObj;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die(){
		Debug.Log(gameObject.name +" is dead");

		alive = false;

		colliderObj.SetActive(false);

		//--show the scoreboard - or start another round
		GameController.EndRoundCountdown();
	}

	public void LoseControl(){
		//--player killed by shooting - now fall to ground
		Rend.color = new Color(0, 0, 0, 1); //--make it black
		DeathExplosion.SetActive(true);
		Invoke("HideExplosion",1);
	}

	public void Explode(){
		//--player has hit ground or had a mid-air collision
		DeathExplosion.SetActive(true);
		Vfx.SetActive(false);
	}

	void HideExplosion(){
		//--so that we can use it again later
		DeathExplosion.SetActive(false);
	}

	public void ResetPlayer(){

		//--called when the round begins again - also on the 1st round
		
		alive = true;

		DamageController.ResetHealth();

		PlayerMovement.MoveToStartPos();

		PlayerMovement.autoPilot = true;

		Invoke("CancelAutopilot", 2);

		DeathExplosion.SetActive(false);

		colliderObj.SetActive(true);
	}

	public void StartAutopilot(){
		Debug.Log("start autopilot");
		PlayerMovement.autoPilot = true;
	}

	void CancelAutopilot(){
		PlayerMovement.autoPilot = false;
	}

	void FixedUpdate () {
		if(Input.GetKey("s")){
			PlayerMovement.MoveToStartPos();
		}

	}
}
