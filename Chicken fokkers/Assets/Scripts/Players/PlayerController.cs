// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool alive = true;
	public int score = 0;
	public float health = 100;
	public bool singlePlayer;
	 public GameObject DeathExplosion;
	 public GameController GameController;
	 public DamageController DamageController;
	 public PlayerMovement PlayerMovement;
	 public ShootController ShootController;
	 public DetachableWheelScript DetachableWheelScript;
	 public PlayerAbility PlayerAbility;
	 public GameObject Vfx;
	 public GameObject CrashingPlayer;
	 public Rigidbody2D rb;
	public float initialHealth;
	 public int playerNum = 1;
	// [HideInInspector]

	void Awake(){
		GameController = GameObject.Find("SceneController").GetComponent<GameController>();
		score = 0;
		Debug.Log("PlayerController for "+gameObject.name+" health = "+health);
		initialHealth = health;
	}

	public void ResetPlayer(){

		//--called when the round begins again - also on the 1st round
		Debug.Log("Reset "+transform.name);
		
		alive = true;
		gameObject.SetActive(true);
		DamageController.ResetDamage();
		health = initialHealth;
		ShootController.ResetFireRate();
		
		Invoke("CancelAutopilot", 2);

		if(DetachableWheelScript){
			DetachableWheelScript.Reset();
		}
		
		PlayerAbility.ResetAbility();
		PlayerMovement.MoveToStartPos();
		StartAutopilot();
		
	}

	public void StartAutopilot(){
		Debug.Log("start autopilot");
		PlayerMovement.autoPilot = true;
	}

	void CancelAutopilot(){
		Debug.Log("cancel autopilot "+transform.name);
		PlayerMovement.autoPilot = false;
	}

	public void Die(){
		Debug.Log(gameObject.name +" is dead");

		alive = false;
		Vector2 vel = rb.velocity;
		ShootController.CancelShooting();
		GameObject crashingPlayer = Instantiate(CrashingPlayer, transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z));
		Instantiate(DeathExplosion, transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z));
		crashingPlayer.GetComponent<Rigidbody2D>().velocity = vel;

		//--check if the player had a wheel showing - if not, hide on crashingPlayer too
		if(DetachableWheelScript){
			if(!DetachableWheelScript.hasWheel){
				crashingPlayer.GetComponent<CrashingScript>().RemoveWheel();
			}
		}
		
		gameObject.SetActive(false);

		//--show the scoreboard - or start another round
		GameController.PlayerHasDied();
	}

	void FixedUpdate () {
		if(Input.GetKey("s")){
			// PlayerMovement.MoveToStartPos();
		}

		if(Input.GetKey("a")){
			StartAutopilot();
		}
	}
}
