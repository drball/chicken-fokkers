using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	// GameObject GameController GameController;
	public bool isCollectable = true;
	public ParticleSystem ParticleTrail;
	public GameObject Vfx;


	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("pickup has collided with "+other.name);

		if (other.tag == "PlayerCollider" && isCollectable){

        	if(other.transform.parent.GetComponent<PlayerAbility>()){
        		other.transform.parent.GetComponent<PlayerAbility>().CollectedPickup();
    			ParticleTrail.Stop();
    			Vfx.SetActive(false);
    			Destroy(gameObject, 3);

    		} 
    		
        }
	}
}
