using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject Owner;
	private float speed = 500f;
	public Renderer rend;
	public Rigidbody2D rb;
	public GameObject Explosion;
	public GameObject GroundExplosion;


	// Use this for initialization
	void Start () {
		// Debug.Log("create new bullet");

		rb.AddForce(transform.up * speed);

	}

	void Update(){
		if (!rend.isVisible){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("bullet with owner:"+Owner.name+" hits = "+other.name+" on "+other.transform.parent.name);

        if (other.tag == "PlayerCollider" && (other.transform.parent.name != Owner.name)){

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
        		return;
        	}

        	if(other.GetComponent<EnemyRagdollDamageController>()){
        		Debug.Log("bullet has hit chicken");
        		other.GetComponent<EnemyRagdollDamageController>().HitByBullet();
        		return;
        	}

        } else if (other.tag == "Ground"){
			Instantiate(GroundExplosion, transform.position, transform.rotation);

        	Destroy(gameObject);
        } 
    }
}
