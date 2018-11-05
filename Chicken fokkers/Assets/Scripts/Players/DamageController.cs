// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour {

	[HideInInspector] public GameObject Player;
	[HideInInspector] public SpriteRenderer Rend;
	[HideInInspector] public PlayerController PlayerController;
	[HideInInspector] public ParticleSystem InjuredSmoke;
	public AudioSource hitSfx;

	[Header("Unity stuff")]
	public Image healthBar;

	// Use this for initialization
	void Awake () {
		ResetColour();
	}

	void Start(){
		InjuredSmoke.Stop();
	}

	public void HitByBullet(){

		hitSfx.Play();

		// Debug.Log("hot by bullet called");
		if(PlayerController.health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			PlayerController.health--;
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

				float otherHealth = other.transform.parent.GetComponent<PlayerController>().health;

				if(PlayerController.health <= otherHealth ){
					PlayerController.health = 0;
					UpdateHealthBar();
					PlayerController.Die();
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
