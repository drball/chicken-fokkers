using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToRigidbody : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to
    private GameObject SwitchToRb;
	private Vector2 force;

	// Use this for initialization
	void Start () {
		InitialObj.SetActive(true);
        SwitchTo.SetActive(false);
        SwitchToRb = GetComponent<Rigidbody>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("other = "+other.name);
        if(alive == true){

            if (gameObject.tag != "Player" || other.tag == "Bullet" && alive == true){

                InitialObj.SetActive(false);
                SwitchTo.SetActive(true);
                alive = false;

                Vector2 otherVelocity = other.GetComponent<Rigidbody2D>().velocity;

                Debug.Log("collided with "+other.name+" mag = "+otherVelocity.magnitude);

                if(alive && otherVelocity.magnitude > 1){
                    force = otherVelocity * 17;
                    SwitchToRb.AddForce(forceAmt, ForceMode2D.Impulse);
                }
            }
        }
    }
}
