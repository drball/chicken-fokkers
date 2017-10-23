using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour {

	[HideInInspector] public GameObject Player;
	[HideInInspector] public SpriteRenderer Rend;
	[HideInInspector] public PlayerController PlayerController;
	[HideInInspector] public ParticleSystem InjuredSmoke;

	[Header("Unity stuff")]
	public Image healthBar;
	
	private float smokeEmissionRate;

	// Use this for initialization
	void Awake () {
		ResetColour();
	}

	void Start(){
		// smokeEmissionRate = InjuredSmoke.emission.rate;
		InjuredSmoke.Stop();
		// Debug.Log("emission rate = "+smokeEmissionRate);

	}

	public void HitByBullet(){

		// Debug.Log("hot by bullet called");
		if(PlayerController.health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			PlayerController.health--;
			Rend.color = new Color(255, 0, 0, 1); //--make it red
			Invoke("ResetColour", 0.06f);
			healthBar.fillAmount = PlayerController.health / PlayerController.initialHealth;
			// healthBar.fillAmount = 0.5f;
			Debug.Log("hit. health = "+PlayerController.health+"/"+PlayerController.initialHealth);

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
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(PlayerController.alive){
	        if (other.tag == "Player"){
				Debug.Log("head on collision!!!!!");

				float otherHealth = other.GetComponent<PlayerController>().health;
				// Debug.Log("health = "+PlayerController.health+" other's health = "+otherHealth);

				if(PlayerController.health <= otherHealth ){
					PlayerController.Die();
				}
				

	        } else if(other.tag == "Ground"){
				Debug.Log("hit ground!!!!!");
				PlayerController.Die();
	        }
		}
    }
}
