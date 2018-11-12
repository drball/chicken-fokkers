// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamageController : MonoBehaviour {

	public SpriteRenderer[] Rends; //--for colour change
	public ParticleSystem InjuredSmoke;
	public int health;
	private int initialHealth;
	public GameObject Explode;
	public GameObject AliveObj;
	public GameObject DeadObj;
	public TurretShooting TurretShootingScript; //--for disabling shooting
	public PolygonCollider2D EnemyCollider; //--for disabling when enemy is dead
	public Slider HealthBar;
	public GameObject HealthBarObj;


	void Start () {
		InjuredSmoke.Stop();
		initialHealth = health;
		ResetColour();
		Explode.SetActive(false);
		DeadObj.SetActive(false);
		HealthBar.value = 1;
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

			Debug.Log("health = "+health + ". initial = "+initialHealth);
			
			float newHealthBarValue = (float)health / (float)initialHealth;

			Debug.Log("new healthbar = "+newHealthBarValue);

			HealthBar.value = newHealthBarValue;
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
		AliveObj.SetActive(false);
		DeadObj.SetActive(true);
		EnemyCollider.enabled = false;
		Destroy(Explode,1f);
		TurretShootingScript.DisableShooting();
		HealthBarObj.SetActive(false);
	}
}
