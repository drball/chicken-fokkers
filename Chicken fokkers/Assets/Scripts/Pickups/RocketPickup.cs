using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickup : MonoBehaviour
{
	// GameObject GameController GameController;
	public bool isCollectable = true;
	public ParticleSystem ParticleTrail;
	public GameObject[] VfxList;
	public AudioSource Sfx; 
	public GameObject SpawnObj;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("pickup has collided with "+other.name);

		if(isCollectable){
			if (other.tag == "PlayerCollider" || other.tag == "PlayerWheel"){

	        	Instantiate(SpawnObj, transform.position, transform.rotation);
	        	isCollectable = false;
        		Sfx.pitch = Random.Range(0.9f, 1.25f);
				Sfx.Play();
    			ParticleTrail.Stop();
    			Destroy(gameObject, 3);

    			foreach(GameObject Vfx in VfxList){
	     			Vfx.SetActive(false);
	     		}
	        } 
		}

		
	}
}
