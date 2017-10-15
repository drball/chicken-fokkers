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
		// smokeEmissionRate = InjuredSmoke.emission.rate;
		InjuredSmoke.Stop();
		DeadSmoke.Stop();
		// Debug.Log("emission rate = "+smokeEmissionRate);

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
				InjuredSmoke.Stop();
				DeadSmoke.Play();
				PlayerController.Die();
				PlayerController.LoseControl();

			} else if ((health <= 50) && (health > 0)){
				InjuredSmoke.Play();
			} 
		}
	}

	void ResetColour(){
		Rend.color = new Color(255f, 255f, 255f, 1f);
	}

	public void ResetHealth(){
		health = initialHealth;
		InjuredSmoke.Stop();
		DeadSmoke.Stop();
	}

	void OnCollisionEnter2D(Collision2D coll) {

		// Debug.Log("player collided with "+coll.name);
		Debug.Log("2player collided with name "+coll.gameObject.name);
		Debug.Log("3player collided with tag "+coll.gameObject.tag);

        if (coll.gameObject.tag == "Player"){
			Debug.Log("head on collision!!!!!");
			// Debug.Log("health = "+health+" other's health = "+coll.gameObject.GetComponent<PlayerController>().GetComponent<DamageController>().health);

			// if(){

			// }
			PlayerController.Explode();
			PlayerController.Die();
			InjuredSmoke.Stop();
			DeadSmoke.Stop();

        } else if(coll.gameObject.tag == "Ground"){
			Debug.Log("hit ground!!!!!");
			PlayerController.Explode();
			PlayerController.Die();
			InjuredSmoke.Stop();
			DeadSmoke.Stop();
        }
    }

}
