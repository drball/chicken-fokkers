using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

	public GameObject Player;
	public SpriteRenderer Rend;
	public PlayerController PlayerController;
	public ParticleSystem InjuredSmoke;
	public ParticleSystem DeadSmoke;
	
	private float smokeEmissionRate;

	// Use this for initialization
	void Awake () {
		ResetColour();
	}

	void Start(){
		// smokeEmissionRate = InjuredSmoke.emission.rate;
		InjuredSmoke.Stop();
		DeadSmoke.Stop();
		// Debug.Log("emission rate = "+smokeEmissionRate);

	}

	public void HitByBullet(){

		// Debug.Log("hot by bullet called");
		if(PlayerController.health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			PlayerController.health--;
			Rend.color = new Color(255, 0, 0, 1); //--make it red
			Invoke("ResetColour", 0.06f);

			if(PlayerController.health <= 0 ){
				InjuredSmoke.Stop();
				DeadSmoke.Play();
				PlayerController.Die();
				PlayerController.LoseControl();

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
		DeadSmoke.Stop();
	}

	void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player"){
			Debug.Log("head on collision!!!!!");

			int otherHealth = other.GetComponent<PlayerController>().health;
			Debug.Log("health = "+PlayerController.health+" other's health = "+otherHealth);

			if(PlayerController.health <= otherHealth ){
				PlayerController.Explode();
				PlayerController.Die();
				InjuredSmoke.Stop();
				DeadSmoke.Stop();
			}
			

        } else if(other.tag == "Ground"){
			Debug.Log("hit ground!!!!!");
			PlayerController.Explode();
			PlayerController.Die();
			InjuredSmoke.Stop();
			DeadSmoke.Stop();
        }
    }

}
