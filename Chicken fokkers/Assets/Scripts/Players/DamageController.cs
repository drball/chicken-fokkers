// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour {

	 public GameObject Player;
	 public SpriteRenderer Rend;
	 public PlayerController PlayerController;
	[HideInInspector] public ParticleSystem InjuredSmoke;
	//[HideInInspector]
	public AudioSource hitSfx;

	[Header("Unity stuff")]
	public Image healthBar;

	// Use this for initialization
	void Awake () {
		
		Debug.Log("Damagecontroller awake for "+Player.name);
		Debug.Log("Damagecontroller, playerNum = "+PlayerController.playerNum);

		//--find the appropriate health bar
		if(PlayerController.playerNum == 1){
			healthBar = GameObject.Find("HealthBarL").GetComponent<Image>();
		} else {
			healthBar = GameObject.Find("HealthBarR").GetComponent<Image>();
		}

		ResetColour();
	}

	void Start(){
		InjuredSmoke.Stop();


	}

	public void HitByBullet(float damageAmt){

		hitSfx.Play();

		if(PlayerController.health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			PlayerController.health -= damageAmt;
			Rend.color = new Color(255, 0, 0, 1); //--make it red
			Invoke("ResetColour", 0.06f);
			UpdateHealthBar();

			if(PlayerController.health <= 0 ){
				InjuredSmoke.Stop();
				PlayerController.Die();

			} else if ((PlayerController.health <= 50) && (PlayerController.health > 0)){
				InjuredSmoke.Play();
			} 
		}
	}

	void ResetColour(){
		Rend.color = new Color(255f, 255f, 255f, 1f);
	}

	public void ResetDamage(){
		InjuredSmoke.Stop();
		healthBar.fillAmount = 1;
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(PlayerController.alive){
	        if (other.tag == "PlayerCollider" /*&& (other.transform.parent.name != Owner.name)*/){
				Debug.Log("head on collision!!!!!");

				PlayerController OtherPlayerController = other.transform.parent.GetComponent<PlayerController>();
				float otherHealth = OtherPlayerController.health;

				if(PlayerController.health < otherHealth ){
					//--this player dies if has less health than other 
					Debug.Log(transform.name+"dies");
					PlayerController.health = 0;
					UpdateHealthBar();
					PlayerController.Die();
				} else if (PlayerController.health == otherHealth){
					//--both players have equal health - choose a random one to die 
					Debug.Log("both players equal, choosing random death");
					bool rand = (Random.value > 0.5f);//--random 0/1
					if(rand == true){
					    PlayerController.health = 0;
						UpdateHealthBar();
						PlayerController.Die();
					} else {
					    OtherPlayerController.health = 0;
					    other.GetComponent<DamageController>().UpdateHealthBar();
					    OtherPlayerController.Die();
					}
				}
				
	        } else if(other.tag == "Ground"){
				Debug.Log("hit ground!!!!!");
				PlayerController.health = 0;
				UpdateHealthBar();
				PlayerController.Die();
	        }
		}
    }

    void UpdateHealthBar(){
    	healthBar.fillAmount = PlayerController.health / PlayerController.initialHealth;
    }
}
