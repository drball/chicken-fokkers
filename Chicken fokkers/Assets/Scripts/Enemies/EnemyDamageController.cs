// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--for an enemy plane

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
	public Rigidbody2D rb;
	public EnemyRagdollDamageController EnemyRagdoll; //--optional, a chicken which will die when this enemy dies


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
		Debug.Log("enemy die!");
		InjuredSmoke.Stop();
		Explode.SetActive(true);
		Explode.transform.parent = null;
		AliveObj.SetActive(false);
		DeadObj.SetActive(true);
		EnemyCollider.enabled = false;
		Destroy(Explode,1f);
		HealthBarObj.SetActive(false);
		if(TurretShootingScript){
			TurretShootingScript.DisableShooting();
		}

		//--if the go we're replacing this with has an rb, pass the vector
		if(DeadObj.GetComponent<Rigidbody2D>()){
			Vector2 vel = rb.velocity;
			// Debug.Log("killed enemy has rb. Give it a velocity of "+vel);
			DeadObj.GetComponent<Rigidbody2D>().velocity = vel;
		}

		//--EnemyDamageController
		if(EnemyRagdoll){
			Debug.Log("kill chicken on "+transform.name);
			EnemyRagdoll.Die();
		}
	}
}
