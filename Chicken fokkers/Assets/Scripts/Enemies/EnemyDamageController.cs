using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public SpriteRenderer[] Rends;
	public ParticleSystem InjuredSmoke;
	public int health;
	private int initialHealth = 10;
	public GameObject Explode;


	void Start () {
		InjuredSmoke.Stop();
		health = initialHealth;
		ResetColour();
		Explode.SetActive(false);
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
		Debug.Log("turret die!");
		InjuredSmoke.Stop();
		Explode.SetActive(true);
		Explode.transform.parent = null;
		Invoke("HideVfx", 0.25f);
		Invoke("RemoveAfterDeath",1f);
	}

	void HideVfx(){
		Debug.Log("turret hide vfx");
		foreach(SpriteRenderer Rend in Rends){
			Rend.enabled = false;
		}
	}

	void RemoveAfterDeath(){
		Destroy(Explode);
		Destroy(gameObject);
	}
}
