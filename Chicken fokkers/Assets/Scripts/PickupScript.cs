using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	// GameObject GameController GameController;
	public bool isCollectable = true;
	public ParticleSystem ParticleTrail;
	public GameObject Vfx;
	public AudioSource Sfx; 


	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("pickup has collided with "+other.name);

		if(isCollectable){
			if (other.tag == "PlayerCollider" || other.tag == "PlayerWheel"){

	        	if(other.transform.parent.GetComponent<PlayerAbility>()){
	        		other.transform.parent.GetComponent<PlayerAbility>().CollectedPickup();
	        		isCollectable = false;
	        		Sfx.pitch = Random.Range(0.9f, 1.25f);
					Sfx.Play();
	    			ParticleTrail.Stop();
	    			Vfx.SetActive(false);
	    			Destroy(gameObject, 3);
	    		} 
	        } 
		}

		
	}

}
