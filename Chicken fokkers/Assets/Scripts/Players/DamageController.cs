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

	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("bullet with owner:"+Owner.name+" hits = "+other.name);

        if (other.tag == "PlayerCollider" && (other.transform.parent.name != Player.name)){

        	if(other.GetComponent<DamageController>()){
        		other.GetComponent<DamageController>().HitByBullet();
        		Debug.Log("head on collision!!!!!");

        		// Instantiate(Explosion, transform.position, transform.rotation);
        		// Debug.Log("hit the other player");

            	// Destroy(gameObject);
    		} 
    		
        } else if (other.tag == "Ground"){
			// Instantiate(Explosion, transform.position, transform.rotation);

        	Destroy(gameObject);
        } 
    }

}
