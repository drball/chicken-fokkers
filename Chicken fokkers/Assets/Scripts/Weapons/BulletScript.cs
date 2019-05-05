// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

//--responsable for hitting things, causing dmage or hitting terrain
public class BulletScript : MonoBehaviour {

	public GameObject Owner;
	// public Renderer[] rend;
	public GameObject Explosion;
	public GameObject GroundExplosion;
	public float damage = 1f;


	// Use this for initialization
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("bullet with owner:"+Owner.name+" hits = "+other.name+" on "+other.transform.parent.name);

		//--if this doesn't have an owner set (like missile), make itself owner
		if(!Owner){
			Owner = gameObject;
		}

        if (other.tag == "PlayerCollider" && (other.transform.parent.name != Owner.name)){

        	if(other.GetComponent<DamageController>()){
        		other.GetComponent<DamageController>().HitByBullet(damage);

        		Instantiate(Explosion, transform.position, transform.rotation);
        		// Debug.Log("hit the other player");

            	Destroy(gameObject);
    		} 
		} else if (other.tag == "Enemy"){
			// Instantiate(GroundExplosion, transform.position, transform.rotation);
			// Debug.Log("Bullet hit ebemy");
			Instantiate(Explosion, transform.position, transform.rotation);
        	Destroy(gameObject);


        	if(other.GetComponent<EnemyDamageController>()){
        		other.GetComponent<EnemyDamageController>().HitByBullet();
        		return;
        	}

        	if(other.GetComponent<EnemyRagdollDamageController>()){
        		// Debug.Log("bullet has hit chicken");
        		other.GetComponent<EnemyRagdollDamageController>().HitByBullet();
        		return;
        	}

        } else if (other.tag == "Ground"){
			Instantiate(GroundExplosion, transform.position, transform.rotation);
        	Destroy(gameObject);
        } 
    }
}
