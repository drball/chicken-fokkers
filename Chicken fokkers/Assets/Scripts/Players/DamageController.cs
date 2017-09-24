using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

	public GameObject Player;
	public int health = 100;
	public SpriteRenderer Rend;
	public PlayerController PlayerController;
	public ParticleSystem InjuredSmoke;
	public ParticleSystem DeadSmoke;
	private int initialHealth;
	private float smokeEmissionRate;

	// Use this for initialization
	void Awake () {
		ResetColour();

		initialHealth = health;
	}

	void Start(){
		smokeEmissionRate = InjuredSmoke.emissionRate;
		InjuredSmoke.emissionRate = 0;
		Debug.Log("emission rate = "+smokeEmissionRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HitByBullet(){

		// Debug.Log("hot by bullet called");
		if(health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			health--;
			Rend.color = new Color(255, 0, 0, 1); //--make it red
			Invoke("ResetColour", 0.06f);

			if(health <= 0 ){
				PlayerController.Die();
			} else if (health <= 50){
				InjuredSmoke.emissionRate = smokeEmissionRate;
			} else if (health <= 0){
				InjuredSmoke.emissionRate = 0;
				DeadSmoke.emissionRate = smokeEmissionRate;
			}
		}
	}

	void ResetColour(){
		Rend.color = new Color(255f, 255f, 255f, 1f);
	}

	public void ResetHealth(){
		health = initialHealth;
		InjuredSmoke.emissionRate = 0;
		DeadSmoke.emissionRate = 0;
	}


}
