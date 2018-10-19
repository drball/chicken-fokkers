using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	private float speed = 200f;
	public Rigidbody2D rb;
	public GameObject Explosion;
	public GameObject GroundExplosion;


	// Use this for initialization
	void Start () {
		rb.AddForce(transform.up * speed);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("bullet with owner:"+Owner.name+" hits = "+other.name+" on "+other.transform.parent.name);

        if (other.tag == "PlayerCollider"){

        	if(other.GetComponent<DamageController>()){
        		other.GetComponent<DamageController>().HitByBullet();

        		Instantiate(Explosion, transform.position, transform.rotation);
        		Debug.Log("hit the other player");

            	Destroy(gameObject);
    		} 
		} else if (other.tag == "Enemy"){
			// Instantiate(GroundExplosion, transform.position, transform.rotation);
			// Debug.Log("Bullet hit ebemy");
			Instantiate(Explosion, transform.position, transform.rotation);
        	Destroy(gameObject);

        	if(other.GetComponent<EnemyDamageController>()){
        		other.GetComponent<EnemyDamageController>().HitByBullet();
        	}

        } else if (other.tag == "Ground"){
			Instantiate(GroundExplosion, transform.position, transform.rotation);

        	Destroy(gameObject);
        } 
    }
}
