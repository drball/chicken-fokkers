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
	public int health = 100;
	public GameObject CrashingPlayer;
	public Rigidbody2D rb;

	private int initialHealth;

	// Use this for initialization
	void Start () {
		score = 0;
		initialHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die(){
		Debug.Log(gameObject.name +" is dead");

		alive = false;

		colliderObj.SetActive(false);

		Vector2 vel = rb.velocity;
		Debug.Log("vel = "+vel);

		gameObject.SetActive(false);

		GameObject crashingPlayer = Instantiate(CrashingPlayer, transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z));
		Instantiate(DeathExplosion, transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z));

		crashingPlayer.GetComponent<Rigidbody2D>().velocity = vel;
		
		//--show the scoreboard - or start another round
		GameController.EndRoundCountdown();
	}

	public void ResetPlayer(){

		//--called when the round begins again - also on the 1st round
		
		alive = true;

		DamageController.ResetDamage();

		health = initialHealth;

		PlayerMovement.MoveToStartPos();

		PlayerMovement.autoPilot = true;

		Invoke("CancelAutopilot", 2);

		// DeathExplosion.SetActive(false);

		colliderObj.SetActive(true);

		Vfx.SetActive(true);
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

	public void ResetHealth(){
		

	}
}
