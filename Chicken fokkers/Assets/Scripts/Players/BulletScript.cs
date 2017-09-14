using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject Owner;
	private float speed = 500f;
	public Rigidbody2D rb;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		Debug.Log("create new bullet");

		rb.AddForce(transform.up * speed);

	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("bullet with owner:"+Owner.name+" hits = "+other.name);

        if (other.tag == "PlayerCollider" && (other.transform.parent.name != Owner.name)){

        	if(other.GetComponent<DamageController>()){
        		other.GetComponent<DamageController>().HitByBullet();

        		Instantiate(Explosion, transform.position, transform.rotation);
        		Debug.Log("hit the other player");

            	Destroy(gameObject);
    		} 
    		
        } else if (other.tag == "Ground"){
			Instantiate(Explosion, transform.position, transform.rotation);

        	Destroy(gameObject);
        } 
    }
}
