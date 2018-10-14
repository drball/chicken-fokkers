using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public SpriteRenderer[] Rends;
	public ParticleSystem InjuredSmoke;
	public int health;
	private int initialHealth = 100;

	// Use this for initialization
	void Awake () {
		ResetColour();
	}

	void Start () {
		InjuredSmoke.Stop();
		health = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HitByBullet(){

		// Debug.Log("hot by bullet called");
		if(health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			health--;
			
			Invoke("ResetColour", 0.06f);
			// UpdateHealthBar();

			foreach(SpriteRenderer Rend in Rends){
				Rend.color = new Color(255, 0, 0, 0.5f); //--make it red
			}

			if(health <= 0 ){
				Die();

			} else if ((health <= (initialHealth/2f)) && (health > 0)){
				InjuredSmoke.Play();
			} 
		}
	}

	void ResetColour(){
		foreach(SpriteRenderer Rend in Rends){
			Rend.color = new Color(255f, 255f, 255f, 1f);
		}
	}

	void Die(){
		InjuredSmoke.Stop();
	}
}
