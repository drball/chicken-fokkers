using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachableWheelScript : MonoBehaviour {

	public GameObject NewWheel;
	public GameObject WheelExplosion;
	public PlayerController PlayerController;
	public Rigidbody2D PlayerRb;
	public bool hasWheel = true;
	private Vector2 playerForce;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log("wheel has collided with "+other.name);

		if(PlayerController.alive){

			if (other.tag == "PlayerCollider" && (other.transform.parent.name != transform.parent.name)){
				// Debug.Log("hit the wheel");
				gameObject.SetActive(false);
				if(NewWheel){
					GameObject newWheel = Instantiate(NewWheel, transform.position, Quaternion.identity);
					// Debug.Log("give wheel force of "+playerForce);
					newWheel.GetComponent<Rigidbody2D>().AddForce(playerForce, ForceMode2D.Impulse);
					hasWheel = false;
				}
				GameObject newWheelExplosion = Instantiate(WheelExplosion, transform.position, Quaternion.identity);

	        } else if(other.tag == "Ground"){
				Debug.Log("wheel hit ground!!!!!");
				gameObject.SetActive(false);
				GameObject newWheelExplosion = Instantiate(WheelExplosion, transform.position, Quaternion.identity);
				hasWheel = false;
	        }
		}
	}

	void Update(){
		playerForce = PlayerRb.velocity;
	}

	public void Reset(){
		gameObject.SetActive(true);
		hasWheel = true;
	}
}
