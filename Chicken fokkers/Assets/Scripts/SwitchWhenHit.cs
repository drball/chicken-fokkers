using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWhenHit : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to
	private Vector2 force;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("other = "+other.name);

        if (gameObject.tag != "Player" || other.tag == "Bullet"){

            Vector2 otherVelocity = other.GetComponent<Rigidbody2D>().velocity;

            Debug.Log("collided with "+other.name+" mag = "+otherVelocity.magnitude);

            if(alive && otherVelocity.magnitude > 1){
            	force = otherVelocity * 17;
            }

            InitialObj.SetActive(false);
            SwitchTo.SetActive(true);
            

            // if(other.GetComponent<BulletScript>()){
            // 	other.GetComponent<BulletScript>().HitPlayer();	
            // }
        }
    }
}
